using Service.Interfaces;
using Service.Models;
using Service.Services;

namespace TiendaHogarDesktop.Views
{
    public partial class ClientesView : Form
    {
        private readonly IGenericService<Cliente> clienteService = new GenericService<Cliente>();
        private readonly IGenericService<Localidad> localidadService = new GenericService<Localidad>();
        private readonly BindingSource ListClientes = new();
        private Cliente? clienteCurrent;
        private readonly ErrorProvider errorProvider = new();

        public ClientesView()
        {
            InitializeComponent();
            Text = "Tienda Hogar - Clientes";
            dataGridClientesView.DataSource = ListClientes;
            dataGridClientesView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridClientesView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            Shown += async (_, _) =>
            {
                await CargarCombo();
                await CargarGrilla();
            };
        }

        private async Task CargarCombo()
        {
            try
            {
                comboLocalidades.DataSource = await localidadService.GetAllAsync(null);
                comboLocalidades.DisplayMember = "Nombre";
                comboLocalidades.ValueMember = "Id";
                comboLocalidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarGrilla(string? filtro = null)
        {
            try
            {
                var clientes = await clienteService.GetAllAsync(filtro);
                ListClientes.DataSource = clientes;
                if (dataGridClientesView.Columns.Contains("Localidad"))
                    dataGridClientesView.Columns["Localidad"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButtonAgregar_Click(object sender, EventArgs e)
        {
            clienteCurrent = null;
            LimpiarCampos();
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                if (clienteCurrent != null)
                {
                    clienteCurrent.Nombre = txtNombre.Text;
                    clienteCurrent.Direccion = txtDireccion.Text;
                    clienteCurrent.Telefono = txtTelefonos.Text;
                    clienteCurrent.LocalidadId = (int)comboLocalidades.SelectedValue!;
                    clienteCurrent.Email = txtEmail.Text;
                    await clienteService.UpdateAsync(clienteCurrent);
                    clienteCurrent = null;
                }
                else
                {
                    var cliente = new Cliente
                    {
                        Nombre = txtNombre.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefonos.Text,
                        LocalidadId = (int)comboLocalidades.SelectedValue!,
                        Email = txtEmail.Text
                    };
                    await clienteService.AddAsync(cliente);
                }
                await CargarGrilla();
                LimpiarCampos();
                tabControl.SelectTab(tabPageLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            clienteCurrent = null;
            LimpiarCampos();
            tabControl.SelectTab(tabPageLista);
        }

        private void iconButtonEditar_Click(object sender, EventArgs e)
        {
            clienteCurrent = (Cliente?)ListClientes.Current;
            if (clienteCurrent == null)
            {
                MessageBox.Show("Seleccione un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtNombre.Text = clienteCurrent.Nombre;
            txtDireccion.Text = clienteCurrent.Direccion;
            txtTelefonos.Text = clienteCurrent.Telefono;
            comboLocalidades.SelectedValue = clienteCurrent.LocalidadId;
            txtEmail.Text = clienteCurrent.Email;
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private async void iconButtonEliminar_Click(object sender, EventArgs e)
        {
            clienteCurrent = (Cliente?)ListClientes.Current;
            if (clienteCurrent == null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var result = MessageBox.Show($"¿Está seguro que desea eliminar el cliente {clienteCurrent.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await clienteService.DeleteAsync(clienteCurrent.Id);
                    await CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            clienteCurrent = null;
        }

        private async void btnBuscar_Click(object sender, EventArgs e) => await CargarGrilla(txtFiltro.Text);

        private bool ValidarCampos()
        {
            errorProvider.Clear();
            bool ok = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Nombre obligatorio");
                ok = false;
            }
            if (comboLocalidades.SelectedIndex < 0)
            {
                errorProvider.SetError(comboLocalidades, "Seleccione una localidad");
                ok = false;
            }
            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonos.Text = string.Empty;
            comboLocalidades.SelectedIndex = -1;
            errorProvider.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

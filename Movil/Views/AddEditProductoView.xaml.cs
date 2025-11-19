using Movil.ViewModels;
using Service.Models;
using Microsoft.Maui.Controls;

namespace Movil.Views;

public partial class AddEditProductoView : ContentPage, IQueryAttributable
{
    public AddEditProductoView()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        query.TryGetValue("ProductToEdit", out var obj);
        var producto = obj as Producto; // será null para alta

        if (BindingContext is AddEditProductoViewModel vm)
        {
            vm.EditProduct = producto;
        }
        else
        {
            void AssignOnContextChanged(object? sender, EventArgs args)
            {
                if (BindingContext is AddEditProductoViewModel vm2)
                {
                    vm2.EditProduct = producto;
                    BindingContextChanged -= AssignOnContextChanged;
                }
            }
            BindingContextChanged += AssignOnContextChanged;
        }
    }
}
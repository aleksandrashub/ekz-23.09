using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using MsBox.Avalonia;
using subenok23.Models;
using System;
using System.Linq;

namespace subenok23;

public partial class Window1 : Window
{
    public Window1()
    {
        InitializeComponent();
        loadProds();
    }
    private void loadProds()
    {






        listbox.ItemsSource = Helper.user724Context.Products.Select(
            x => new
            {
                x.IdProduct,
                x.NameProduct,
                x.IdManufacturerNavigation.NameManufacturer,
                x.Cost,
                x.Descriprion,
                Photo = new Bitmap($"Assets" + "\\" + x.Image.ToString()),
                Discount = Helper.user724Context.Products.Where(z => z.IdProduct == x.IdProduct).FirstOrDefault().IdDiscountNavigation.ValueDiscount,
            }); 
    
    
    }

    private void ListBox_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        //  if (PointerPressedEvent.OwnerType.)
        var point = e.GetCurrentPoint(sender as Control);
      //  point.Properties.IsRightButtonPressed = true;
        if (point.Properties.IsRightButtonPressed == true)
        {
            Helper.CurrentProduct = listbox.SelectedItem as Product;
           // Helper.CurrentProduct = Helper.user724Context.Products.Where(x => x.IdProduct == ind).FirstOrDefault();
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();


        }
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        Helper.CurrentProduct = Helper.user724Context.Products.Where(x => x.IdProduct == ind).FirstOrDefault();
        Window3 window3 = new Window3();
        window3.Show();
        this.Close();
    }

    private void Vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        this.Close();

    }

    private void VKorzinu_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Window2 window2 = new Window2();
        window2.Show();
        this.Close();

    }
}
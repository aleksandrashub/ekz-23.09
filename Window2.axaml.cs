using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Microsoft.EntityFrameworkCore;
using subenok23.Models;
using System.Linq;

namespace subenok23;

public partial class Window2 : Window
{
    public Window2()
    {
        InitializeComponent();
        foreach (int id in Helper.idsZakaz)
        {
            foreach (Product pr in Helper.user724Context.Products)
            {
                if (id == pr.IdProduct && Helper.Zakaz.Contains(pr)== false)
                {
                    Helper.Zakaz.Add(pr);
                }
            }
        }
        loadKorzProds();
    }

    private void loadKorzProds()
    {
        punktCmb.ItemsSource = Helper.user724Context.PunktVydahis.Select(x => x.NamePunkt).ToList();
        
        listboxKorz.ItemsSource = Helper.Zakaz.Select(
            x => new
            {
                x.IdProduct,
                x.NameProduct,
                Photo = new Bitmap($"Assets" + "\\" + x.Image.ToString()),
                x.Cost,
                x.Descriprion,
                Discount = Disc(x.IdProduct),
                amount = amountOutput(x.IdProduct)

            }); ;
    
    
    }

    private int amountOutput(int id)
    {
        int am = Helper.user724Context.ZakazProducts.Where(x => x.IdProduct == id).FirstOrDefault().Amount.Value;
        return am;
    }
    private string Disc(int id)
    {
        string disc = Helper.user724Context.Products.Where(x => x.IdProduct == id).FirstOrDefault().IdDiscount.ToString();
        switch (disc)
        {
            case "0":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 0).FirstOrDefault().ValueDiscount.ToString();
                break;
            case "1":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 1).FirstOrDefault().ValueDiscount.ToString();
                break;
            case "2":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 2).FirstOrDefault().ValueDiscount.ToString();
                break;
            case "3":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 3).FirstOrDefault().ValueDiscount.ToString();
                break;
            case "4":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 4).FirstOrDefault().ValueDiscount.ToString();
                break;
            case "5":
                disc = Helper.user724Context.Discounts.Where(x => x.IdDiscount == 5).FirstOrDefault().ValueDiscount.ToString();
                break;
        
        }

        return disc;
    }



    private void Minus_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int amount;
        int ind = (int)((sender as Button)!).Tag!;
        int id = Helper.user724Context.ZakazProducts.Where(x => x.IdProduct == ind).FirstOrDefault().IdZakaz;
       
             amount = Helper.user724Context.ZakazProducts.Where(x => x.IdProduct == ind).FirstOrDefault().Amount.Value - 1;
            Helper.user724Context.ZakazProducts.Where(x => x.IdZakaz == id).FirstOrDefault().Amount = amount;
            if (amount == 0)
            {
                Zakaz zakaz = new Zakaz();
                zakaz = Helper.user724Context.Zakazs.Where(x => x.IdZakaz == id).FirstOrDefault();

                ZakazProduct zakazProduct = new ZakazProduct();
                zakazProduct = zakaz.ZakazProducts.Where(x => x.IdProduct == ind).FirstOrDefault();
                int idPr = zakazProduct.IdProduct;
                Helper.idsZakaz.Remove(idPr);
            Product pr = new Product();
            pr = Helper.Zakaz.Where(x => x.IdProduct == ind).FirstOrDefault();
            Helper.Zakaz.Remove(pr);
            Helper.user724Context.ZakazProducts.Remove(zakazProduct);
                Helper.user724Context.Zakazs.Remove(zakaz);
            }
        
       
        Helper.user724Context.SaveChanges();
        loadKorzProds();
    }

    private void Plus_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int ind = (int)((sender as Button)!).Tag!;
        int id = Helper.user724Context.ZakazProducts.Where(x => x.IdProduct == ind).FirstOrDefault().IdZakaz;
        int amount = Helper.user724Context.ZakazProducts.Where(x => x.IdProduct == ind).FirstOrDefault().Amount.Value;
        amount = amount + 1;
        Helper.user724Context.ZakazProducts.Where(x => x.IdZakaz == id).FirstOrDefault().Amount = amount;

        Helper.user724Context.SaveChanges();
        loadKorzProds();
    }

    private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        Helper.zakaz.IdPunkt = Helper.user724Context.PunktVydahis.Where(x => x.NamePunkt == listboxKorz.SelectedValue).FirstOrDefault().IdPunkt;

        loadKorzProds();
    }

    private void Vyhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Window1 window1 = new Window1();
        window1.Show();
        this.Close();

    }
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Metsys.Bson;
using MsBox.Avalonia;
using subenok23.Models;
using System;
using System.Linq;

namespace subenok23;

public partial class Window3 : Window
{
    public int codeRand;
    public Window3()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {


        Helper.CurrentProduct = null;
        Window1 window1 = new Window1();
        window1.Show();
        this.Close();
       
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
            
            ZakazProduct zakazProduct = new ZakazProduct();
            if (Helper.idsZakaz.Contains(zakazProduct.IdProduct))
            {
                var msg = MessageBoxManager.GetMessageBoxStandard("Уведомление", "Этот товар уже содержитсмя в корзине");
                msg.ShowAsync();
            }
            else
            {
                zakazProduct.IdProduct = Helper.CurrentProduct.IdProduct;
                zakazProduct.Amount = 1;
                Helper.idsZakaz.Add(zakazProduct.IdProduct);
                Zakaz zakaz = new Zakaz();
                if (Helper.user724Context.ZakazProducts.Count() > 0)
                {
                    zakazProduct.IdZakaz = Helper.user724Context.ZakazProducts.OrderBy(x => x.IdZakaz).FirstOrDefault().IdZakaz + 1;
                }
                else
                {
                    zakazProduct.IdZakaz = 0;
                }
                zakaz.IdZakaz = zakazProduct.IdZakaz;
                zakaz.Date = DateOnly.FromDateTime(DateTime.Now);
                zakaz.IdStatus = 1;
                Random rnd = new Random();
                codeRand = rnd.Next();
                while (codeRand.ToString().Length != 3)
                {
                    codeRand = rnd.Next();
                }
                zakaz.Code = codeRand;
                if (Helper.currUser != null)
                {
                    zakaz.IdUser = Helper.currUser.IdUser;
                }
                Helper.user724Context.Products.Where(x => x.IdProduct == Helper.CurrentProduct.IdProduct).FirstOrDefault().ZakazProducts.Add(zakazProduct);
                zakaz.ZakazProducts.Add(zakazProduct);

                Helper.user724Context.Zakazs.Add(zakaz);

                Helper.user724Context.SaveChanges();

            }
                

            Window2 window2 = new Window2();
            window2.Show();
            this.Close();

       
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly List<Product> _products;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _products = SeedDataProducts();
    }

    public IActionResult Index()
    {
        return View(_products);
    }

    public IActionResult Detail([FromRoute] int Id)
    {
        Product product = _products.Find(c => c.Id == Id);
        if (product is null) return View(new Catalog());

        List<Product> products = _products.FindAll(c => string.Equals(c.GroupCode, product.GroupCode))
            .Where(c => c.Id != product.Id).ToList();

        Catalog catalog = new()
        {
            Product = product,
            Products = products
        };
        return View(catalog);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private static List<Product> SeedDataProducts()
    {
        return new List<Product>
        {
            new()
            {
                Id = 1,
                GroupCode = "TSRT-01",
                BrandName = "LCWAIKIKI Basic",
                CategoryName = "Erkek Tişört",
                Color = "Haki",
                Title = "Bisiklet Yaka Kısa Kollu Penye Erkek Tişört",
                Price = 99.99f,
                Stock = 30,
                Thumbnail =
                    "https://img-lcwaikiki.mncdn.com/mnresize/600/800/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a.jpg",
                Images = new List<string>
                {
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a1.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a2.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a3.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2-102-88-96-190_a4.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2_u.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-lw2_u1.jpg"
                },
                Features = new List<Feature>
                {
                    new()
                    {
                        Name = "Beden",
                        FeatureItems = new List<FeatureItem>
                            { new() { Name = "S" }, new() { Name = "M" }, new() { Name = "L" } }
                    }
                },
                Description = @"Ürün Açıklaması
                                Erkek giyiminin şık parçalarından kısa kollu tişört %100 pamuklu kumaştan dokusuyla günlük hayatın yoğun temposuna en iyi şekilde eşlik eder. Terletmez, cilde nefes aldırır. Kombinlendiği parçalara göre her tarzın temsilcisi haline gelebilir.
                                Manken Bilgisi
                                Göğüs: 102 cm Bel: 88 cm Basen: 96 cm Boy: 190 cm
                                Manken M beden ürün giyiyor.

                                Ürün İçeriği ve Özellikleri
                                Ürün İçeriği:
                                Ana Kumaş: %100 Pamuk

                                Ürün Özellikleri:

                                Cinsiyet: Erkek

                                Stil: Casual/Günlük

                                Kalıp: Rahat Kalıp

                                Ürün Tip: Tişört

                                Kalınlık: İnce

                                Yaka: Bisiklet Yaka

                                Marka: LCWAIKIKI Basic

                                Kol Boyu: Kısa Kol

                                Desen: Düz

                                Kumaş: Penye

                                Malzeme: %100 Pamuk"
            },
            new()
            {
                Id = 2,
                GroupCode = "TSRT-01",
                BrandName = "LCWAIKIKI Basic",
                CategoryName = "Erkek Tişört",
                Color = "Mavi",
                Title = "Bisiklet Yaka Kısa Kollu Penye Erkek Tişört",
                Price = 99.99f,
                Stock = 30,
                Thumbnail =
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a.jpg",
                Images = new List<string>
                {
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a1.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a2.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a3.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-102-88-96-190_a4.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-94-92-102-165_5.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs-94-92-102-165_6.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs_u.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-ffs_u1.jpg"
                },
                Features = new List<Feature>
                {
                    new()
                    {
                        Name = "Beden",
                        FeatureItems = new List<FeatureItem>
                            { new() { Name = "S" }, new() { Name = "M" }, new() { Name = "L" } }
                    }
                },
                Description = @"Ürün Açıklaması
                                Erkek giyiminin şık parçalarından kısa kollu tişört %100 pamuklu kumaştan dokusuyla günlük hayatın yoğun temposuna en iyi şekilde eşlik eder. Terletmez, cilde nefes aldırır. Kombinlendiği parçalara göre her tarzın temsilcisi haline gelebilir.
                                Manken Bilgisi
                                Göğüs: 102 cm Bel: 88 cm Basen: 96 cm Boy: 190 cm
                                Manken M beden ürün giyiyor.

                                Ürün İçeriği ve Özellikleri
                                Ürün İçeriği:
                                Ana Kumaş: %100 Pamuk

                                Ürün Özellikleri:

                                Cinsiyet: Erkek

                                Stil: Casual/Günlük

                                Kalıp: Rahat Kalıp

                                Ürün Tip: Tişört

                                Kalınlık: İnce

                                Yaka: Bisiklet Yaka

                                Marka: LCWAIKIKI Basic

                                Kol Boyu: Kısa Kol

                                Desen: Düz

                                Kumaş: Penye

                                Malzeme: %100 Pamuk"
            },
            new()
            {
                Id = 3,
                GroupCode = "TSRT-01",
                BrandName = "LCWAIKIKI Basic",
                CategoryName = "Erkek Tişört",
                Color = "Kırmızı",
                Title = "Bisiklet Yaka Kısa Kollu Penye Erkek Tişört",
                Price = 99.99f,
                Stock = 30,
                Thumbnail =
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a.jpg",
                Images = new List<string>
                {
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a1.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a2.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a3.jpg",
                    "https://img-lcwaikiki.mncdn.com/mnresize/1020/1360/pim/productimages/20231/6041132/v1/l_20231-s30113z8-hjy-100-84-86-188_a4.jpg"
                },
                Features = new List<Feature>
                {
                    new()
                    {
                        Name = "Beden",
                        FeatureItems = new List<FeatureItem>
                            { new() { Name = "S" }, new() { Name = "M" }, new() { Name = "L" } }
                    }
                },
                Description = @"Ürün Açıklaması
                                Erkek giyiminin şık parçalarından kısa kollu tişört %100 pamuklu kumaştan dokusuyla günlük hayatın yoğun temposuna en iyi şekilde eşlik eder. Terletmez, cilde nefes aldırır. Kombinlendiği parçalara göre her tarzın temsilcisi haline gelebilir.
                                Manken Bilgisi
                                Göğüs: 102 cm Bel: 88 cm Basen: 96 cm Boy: 190 cm
                                Manken M beden ürün giyiyor.

                                Ürün İçeriği ve Özellikleri
                                Ürün İçeriği:
                                Ana Kumaş: %100 Pamuk

                                Ürün Özellikleri:

                                Cinsiyet: Erkek

                                Stil: Casual/Günlük

                                Kalıp: Rahat Kalıp

                                Ürün Tip: Tişört

                                Kalınlık: İnce

                                Yaka: Bisiklet Yaka

                                Marka: LCWAIKIKI Basic

                                Kol Boyu: Kısa Kol

                                Desen: Düz

                                Kumaş: Penye

                                Malzeme: %100 Pamuk"
            }
        };
    }
}
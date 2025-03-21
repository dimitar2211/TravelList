using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
public class AirlinesController : Controller
{
    private static List<Airline> airlines = new List<Airline>
    {
        new Airline { Id = 1, Name = "Emirates", Description = "Emirates е една от най-луксозните авиокомпании в света и символ на висококачествено обслужване. Базирана в Дубай, тя предлага полети до шест континента. Известна е с модерния си флот, включително най-голямата флотилия от Airbus A380 и Boeing 777 в света. Пътниците се наслаждават на просторни седалки, гурме храна и развлекателна система ICE с над 4 500 канала. Първа и бизнес класа разполагат с частни кабини и душове на борда.", ImageUrl = "https://cdn.lhsystems.com/2021-04/Emirates_Boeing777-300er.jpg", Rating = 4.5, RatingCount = 10 },
        new Airline { Id = 2, Name = "Qatar Airways", Description = "Qatar Airways е петзвездна авиокомпания, известна със своята луксозна услуга и новаторски продукти като Qsuite – първата в света бизнес класа със затварящи се врати. Компанията редовно печели награди за най-добра авиокомпания в света и най-добра бизнес класа. Предлага отлична кухня, удобни кресла и впечатляваща развлекателна система Oryx One. Централният ѝ хъб в Доха е един от най-модерните летищни комплекси в света.", ImageUrl = "https://d21buns5ku92am.cloudfront.net/69647/images/491615-image00001-13f37c-original-1688396898.jpeg", Rating = 4.2, RatingCount = 15 },
        new Airline { Id = 3, Name = "Singapore Airlines", Description = "Singapore Airlines е една от най-реномираните авиокомпании с перфектно обслужване и модерна флота, включваща Boeing 787 Dreamliner и Airbus A350. Компанията беше първата, която представи Airbus A380 в търговската авиация. Пътниците се наслаждават на елегантни кабини, гурме храна, персонализирано обслужване и водеща в индустрията развлекателна система KrisWorld. Singapore Airlines често печели награди за най-добър персонал в авиацията.", ImageUrl = "https://etimg.etb2bimg.com/thumb/msid-102194271,imgsize-57678,width-1200,height=765,overlay-ettravel/aviation/international/singapore-airlines-flags-near-term-competition-in-international-travel.jpg", Rating = 3.8, RatingCount = 8 },
        new Airline { Id = 4, Name = "Lufthansa", Description = "Lufthansa е най-голямата авиокомпания в Европа и член-основател на Star Alliance. Тя предлага висококачествени услуги в икономична, премиум икономична, бизнес и първа класа. Компанията е известна с немската си прецизност и комфорт, както и с модерните си самолети, включително Boeing 747-8 и Airbus A350. Lufthansa има едни от най-добрите летищни салони и програми за лоялност.", ImageUrl = "https://www.airport-technology.com/wp-content/uploads/sites/14/2023/10/CITY-AIRLINES.jpg", Rating = 4.9, RatingCount = 5 },
        new Airline { Id = 5, Name = "Delta Air Lines", Description = "Delta е една от най-старите и най-големи авиокомпании в света, базирана в САЩ. Тя разполага с един от най-големите и разнообразни флоти, включващ Airbus A220, Boeing 757 и Airbus A330. Компанията се отличава с надеждност, отлични летищни салони и удобна програма за лоялност SkyMiles. Delta предлага модерни удобства на борда, включително високоскоростен Wi-Fi и удобни седалки в бизнес класата Delta One.", ImageUrl = "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-560w,f_auto,q_auto:best/rockcms/2025-03/250320-delta-airlines-crash-vl-934a-0d58e2.jpg", Rating = 1.0, RatingCount = 12 }
    };

    public IActionResult Index()
    {
        return View(airlines);
    }

    [HttpPost]
    public IActionResult Rate(int id, int rating)
    {
        var airline = airlines.FirstOrDefault(a => a.Id == id);
        if (airline != null && rating >= 1 && rating <= 5)
        {
            airline.Rating = Math.Round(((airline.Rating * airline.RatingCount) + rating) / (airline.RatingCount + 1), 2, MidpointRounding.AwayFromZero);
            airline.RatingCount++;

            return Json(new { success = true, newRating = airline.Rating });
        }
        return Json(new { success = false });
    }
}

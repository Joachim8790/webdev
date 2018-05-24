using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using VBTicketVerkoop.Domain;
using VBTicketVerkoop.Service;
using VBTicketVerkoop.ViewModels;


namespace VBTicketVerkoop.Controllers
{
    public class HomeController : Controller
    {
        GebruikerService gservice = new GebruikerService();
        PloegService plservice = new PloegService();
        PlaatsService pservice = new PlaatsService();
        StadionService staservice = new StadionService();
        TicketService tservice = new TicketService();
        WedstrijdService wservice = new WedstrijdService();
        AboService aservice = new AboService();
        PrijsService prservice = new PrijsService();
        WinkelmandlijnService winkservice = new WinkelmandlijnService();
        BestellingService bservice = new BestellingService();
        BestellijnService blservice = new BestellijnService();

        public ActionResult Index()
        {
            return View();


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]
        public ActionResult Shop()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            SelectListItem placeholder = new SelectListItem();
            placeholder.Text = "Selecteer een ploeg";
            placeholder.Value = "-1";
            placeholder.Selected = true;
            listItems.Add(placeholder);
            ShopViewModel vm = new ShopViewModel();
            List<Ploeg> ploegen = plservice.All();
            for (int i = 0; i < ploegen.Count; i++)
            {
                SelectListItem li = new SelectListItem();
                li.Selected = false;
                li.Text = ploegen.ElementAt(i).naam;
                li.Value = i.ToString();
                listItems.Add(li);
            }
            vm.Abonnementen = aservice.All();
            vm.abonnementPlaatsen = pservice.All();
            vm.ploegen = listItems;
            vm.plaatsen = pservice.All();
            vm.stadia = staservice.All();
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Shop(ShopViewModel vm)
        {
            for (int i = 0; i < vm.numberOfAbos.Count(); i++)
            {
                Abo abo = aservice.getAboByPloegPlaats(vm.geselecteerdePloeg+1, i+1);
                for (int j = 0; j < vm.numberOfAbos[i]; j++)
                {
                    Winkelmandlijn wml = new Winkelmandlijn();
                    wml.AboID = abo.aboID;
                    wml.gebruikerID = User.Identity.GetUserId();
                    winkservice.AddLine(wml);
                }
            }
            return RedirectToAction("Winkelmandje", "Home");
        }
        [HttpPost]
        [Authorize]
        public JsonResult deleteRow(int i)
        {

            winkservice.DeleteLine(winkservice.getLineByID(i));
            return Json(new { success = true });

        }
        [Authorize]
        public ActionResult Winkelmandje()
        {
            WinkelmandViewModel vm = new WinkelmandViewModel();
            vm.gebruiker = gservice.getGebruikerByID(User.Identity.GetUserId());
            vm.winkelmandlijnen = winkservice.getLinesFromUser(vm.gebruiker.gebruikerID);

            List<Plaats> plaatsen = new List<Plaats>();
            List<Ploeg> thuisploegen = new List<Ploeg>();
            List<Ploeg> uitploegen = new List<Ploeg>();
            List<Prijs> prijzen = new List<Prijs>();
            List<Stadion> stadions = new List<Stadion>();

            List<Abo> abonnementen = new List<Abo>();
            List<Ploeg> Abonnementploegen = new List<Ploeg>();
            List<Plaats> Abonnementplaatsen = new List<Plaats>();
            List<double> Abonnementprijzen = new List<double>();
            List<Stadion> AbonnementStadions = new List<Stadion>();
            int[] ids = new int[vm.winkelmandlijnen.Count()];



            for (int i = 0; i < vm.winkelmandlijnen.Count(); i++)
            {
                if (vm.winkelmandlijnen.ElementAt(i).AboID == null)
                {
                    Ticket ticket = tservice.All().Where(x => x.ticketID == vm.winkelmandlijnen.ElementAt(i).TicketID).FirstOrDefault();
                    Wedstrijd wedstrijd = wservice.getWedstrijdByID(ticket.wedstrijdID);
                    Prijs prijs = prservice.getPriceByID(ticket.PrijsID);
                    Plaats plaats = pservice.getPlaatsByID(prijs.plaatsID);
                    Ploeg thuis = plservice.getPloegByID(wedstrijd.thuisID);
                    Ploeg uit = plservice.getPloegByID(wedstrijd.uitID);
                    Stadion stadion = staservice.getStadionByID(prijs.stadionID);
                    plaatsen.Add(plaats);
                    thuisploegen.Add(thuis);
                    uitploegen.Add(uit);
                    prijzen.Add(prijs);
                    stadions.Add(stadion);


                }
                else
                {
                    Abo abonnement = aservice.getAboByID(vm.winkelmandlijnen.ElementAt(i).AboID.Value);
                    Ploeg abonnementPloeg = plservice.getPloegByID(abonnement.ploegID);
                    Stadion abonnementStadion = staservice.getStadionByID(abonnementPloeg.stadionID);
                    Plaats abonnementPlaats = pservice.getPlaatsByID(abonnement.plaatsID);
                    Abonnementplaatsen.Add(abonnementPlaats);
                    AbonnementStadions.Add(abonnementStadion);
                    Abonnementploegen.Add(abonnementPloeg);
                    Abonnementprijzen.Add(abonnement.prijs);

                }

                ids[i] = vm.winkelmandlijnen.ElementAt(i).ID;
            }
            vm.abonnementPlaats = Abonnementplaatsen;
            vm.abonnementPloeg = Abonnementploegen;
            vm.abonnementPrijs = Abonnementprijzen;
            vm.abonnementStadion = AbonnementStadions;

            vm.stadion = stadions;
            vm.thuis = thuisploegen;
            vm.uit = uitploegen;
            vm.prijs = prijzen;
            vm.plaats = plaatsen;

            vm.winkelmandlineIDS = ids;



            return View(vm);
        }
        [HttpPost]
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> Winkelmandje(WinkelmandViewModel vm)
        {
            IList<Winkelmandlijn> lines = new List<Winkelmandlijn>();
            for (int i = 0; i < vm.winkelmandlineIDS.Count(); i++)
            {
                lines.Add(winkservice.getLineByID(vm.winkelmandlineIDS[i]));
            }
            for (int i = 0; i < lines.Count(); i++)
            {

            }
            Bestelling bestelling = new Bestelling();
            bestelling.gebruikerID = User.Identity.GetUserId();
            bestelling.date = DateTime.Today.Date;
            bestelling = bservice.Create(bestelling);
            IdentityMessage msg = new IdentityMessage();
            msg.Subject = "Uw bestelling";
            msg.Destination = gservice.getGebruikerByID(User.Identity.GetUserId()).email;
            string content = "<h4>Uw bestelling</h4><p>Hieronder vindt u een overzicht van uw bestelling:</p><table style='text-align:center;'><thead style='background:#333;color:#fff;'><tr><td>Type</td><td>Wedstrijd</td><td>Prijs</td><td>Plaats</td></tr></thead><tbody>";
            for (int i = 0; i < lines.Count(); i++)
            {
                Bestellijn line = new Bestellijn();
                if (lines.ElementAt(i).AboID == null)
                {


                    line.ticketID = lines.ElementAt(i).TicketID;
                    Ticket t = tservice.getTicketByID(line.ticketID.Value);
                    Wedstrijd w = wservice.getWedstrijdByID(t.wedstrijdID);
                    Ploeg thuis = plservice.getPloegByID(w.thuisID);
                    Ploeg uit = plservice.getPloegByID(w.uitID);
                    line.bestellingID = bestelling.BestellingID;
                    Prijs p = prservice.getPriceByID(t.PrijsID);
                    Plaats pl = pservice.getPlaatsByID(p.plaatsID);
                    content += "<tr><td>Ticket</td><td>" + thuis.naam + " - " + uit.naam + "</td><td>" + p.prijs + ",00</td><td>" + pl.plaatsNaam + "</td></tr>";
                }
                else
                {
                    line.aboID = lines.ElementAt(i).AboID;
                    Abo a = aservice.getAboByID(line.aboID.Value);
                    line.bestellingID = bestelling.BestellingID;
                    Plaats pl = pservice.getPlaatsByID(a.plaatsID);
                    Ploeg ploeg = plservice.getPloegByID(a.ploegID);
                    content += "<tr><td>Abonnement</td><td>" + ploeg.naam + "</td><td>" + a.prijs + ",00</td><td>" + pl.plaatsNaam + "</td></tr>";
                }
                blservice.Create(line);
            }
            content += "</tbody></table>";
            winkservice.DeleteLinesFromUser(User.Identity.GetUserId());
            msg.Body = content;
            EmailService service = new EmailService();
            await service.SendAsync(msg);







            return RedirectToAction("OrderBevestiging", "Home");
        }
        [Authorize]
        public ActionResult Wedstrijd(int id)
        {
            WedstrijdViewModel vm = new WedstrijdViewModel();
            vm.wedstrijd = wservice.getWedstrijdByID(id);
            vm.WedstrijdID = id;
            vm.thuisPloeg = plservice.getPloegByID(vm.wedstrijd.thuisID);
            vm.uitPloeg = plservice.getPloegByID(vm.wedstrijd.uitID);
            vm.stadion = staservice.getStadionByID(vm.wedstrijd.stadionID);
            vm.plaatsen = pservice.All();
            vm.prijzen = prservice.getPricesByStadion(vm.stadion.stadionID);


            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Wedstrijd(WedstrijdViewModel vm)
        {
            double totalTickets = 0;
            for (int i = 0; i < vm.numberOfTickets.Count(); i++)
            {
                totalTickets += vm.numberOfTickets[i];
            }
            int aantalTicketsInWinkelmandje = winkservice.countTickets(winkservice.getLinesFromUser(User.Identity.GetUserId()));
            if (totalTickets+aantalTicketsInWinkelmandje > 10)
            {
                return Json(new { success = false, message = "Je kan maximum 10 tickets per keer kopen. Pas je bestelling aan" });
            }
            else
            {
                Wedstrijd Wedstrijd = wservice.getWedstrijdByID(vm.WedstrijdID);
                if (DateTime.Today.AddMonths(1) > Wedstrijd.date)//zorgt ervoor dat je niet meer dan een maand op voorhand kan bestellen
                {
                    List<Plaats> plaatsen = pservice.All().ToList();
                    List<Prijs> prijzen = prservice.getPricesByStadion(Wedstrijd.stadionID).ToList();
                    if (placeLeft(vm.numberOfTickets, Wedstrijd) == "Volgende plaatsen zijn uitverkocht: ")
                    {
                        for (int i = 0; i < plaatsen.Count(); i++)
                        {

                            for (int j = 0; j < vm.numberOfTickets[i]; j++)
                            {
                                Ticket ticket = new Ticket();
                                ticket.wedstrijdID = Wedstrijd.wedstrijdID;
                                ticket.PrijsID = prijzen.ElementAt(i).prijsID;
                                ticket = tservice.Add(ticket);
                                Winkelmandlijn wml = new Winkelmandlijn();
                                wml.gebruikerID = User.Identity.GetUserId();
                                wml.TicketID = ticket.ticketID;
                                winkservice.AddLine(wml);
                            }
                        }
                        return Json(new { success = true });
                    }
                    else
                    {
                        return Json(new { success = false,message = placeLeft(vm.numberOfTickets, Wedstrijd) });
                    }
                    
                }
                else
                {
                    return Json(new { success = false, message= "Je kan ten minste een maand op voorhand tickets bestellen." });
                }
                



                
            }
             



        }
        [Authorize]
        [HttpPost]
        public ActionResult ListTickets(int selectedIndex)
        {
            if (selectedIndex == -1)
            {
                return Json(new { success = true, thuisploegen = "null", uitploegen = "null", datums = "null", stadions = "null" });
            }
            else
            {
                Ploeg selectedPloeg = plservice.All().ElementAt(selectedIndex);
                List<Wedstrijd> wedstrijden = wservice.getWedstrijdenByPloeg(selectedPloeg.ploegID);
                List<Abo> abonnementen = aservice.getAbosByPloeg(selectedPloeg.ploegID);
                wedstrijden = wedstrijden.OrderBy(x => x.date).ToList();

                string[] wedstrijdIDS = new string[wedstrijden.Count];
                string[] thuisploegen = new string[wedstrijden.Count];
                string[] uitploegen = new string[wedstrijden.Count];
                string[] datums = new string[wedstrijden.Count];
                string[] stadions = new string[wedstrijden.Count];
                string[] abonnementPrijzen = new string[abonnementen.Count];
                string[] plaatsen = pservice.All().Select(x => x.plaatsNaam).ToArray();

                for (int i = 0; i < wedstrijden.Count; i++)
                {
                    wedstrijdIDS[i] = wedstrijden.ElementAt(i).wedstrijdID.ToString();
                    thuisploegen[i] = plservice.getPloegByID(wedstrijden.ElementAt(i).thuisID).naam;
                    uitploegen[i] = plservice.getPloegByID(wedstrijden.ElementAt(i).uitID).naam;
                    datums[i] = wedstrijden.ElementAt(i).date.ToString();
                    stadions[i] = staservice.getStadionByID(wedstrijden.ElementAt(i).stadionID).naam;

                }
                for (int i = 0; i < abonnementen.Count; i++)
                {
                    abonnementPrijzen[i] = abonnementen.ElementAt(i).prijs.ToString();

                }




                return Json(new { success = true, thuisploegen = thuisploegen, uitploegen = uitploegen, datums = datums, stadions = stadions, wedstrijdIDS = wedstrijdIDS, abonnementPrijzen = abonnementPrijzen,plaatsen=plaatsen });


            }
        }
        [Authorize]
        public ActionResult OrderBevestiging()
        {
            return View();
        }
        [Authorize]
        public ActionResult Bestelhistoriek()
        {
            BestelHistoriekViewModel vm = new BestelHistoriekViewModel();
            vm.Bestellingen = bservice.getBestellingByGebruiker(User.Identity.GetUserId());
            List<List<Bestellijn>> Bestellingslijnen = new List<List<Bestellijn>>();
            List<double> subtotalen = new List<double>();
            for (int i = 0; i < vm.Bestellingen.Count(); i++)
            {
                double subtotaal = 0;
                Bestellingslijnen.Add(blservice.getBestellijnByBestelling(vm.Bestellingen.ElementAt(i).BestellingID).ToList());
                for (int j = 0; j < Bestellingslijnen.ElementAt(i).Count(); j++)
                {
                   
                    if (Bestellingslijnen.ElementAt(i).ElementAt(j).aboID == null)
                    {
                        subtotaal += prservice.getPriceByID(tservice.getTicketByID(Bestellingslijnen.ElementAt(i).ElementAt(j).ticketID.Value).PrijsID).prijs;
                    }
                    else
                    {
                        subtotaal += aservice.getAboByID(Bestellingslijnen.ElementAt(i).ElementAt(j).aboID.Value).prijs;
                    }
                }
                subtotalen.Add(subtotaal);
            }
            vm.TotaalBedragen = subtotalen;
            return View(vm);
        }
        [Authorize]
        public ActionResult Bestelling(int id)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel();
            vm.Bestelling = bservice.getBestellingByID(id);
            List<Bestellijn> bestellijnen = blservice.getBestellijnByBestelling(id).ToList();
           
            List<Ploeg> aboPloegen = new List<Ploeg>();
            List<Ploeg> thuisPloegen = new List<Ploeg>();
            List<Ploeg> uitPloegen = new List<Ploeg>();
            List<Abo> abos = new List<Abo>();
            List<Prijs> prijzen = new List<Prijs>();
            List<Plaats> plaatsen = new List<Plaats>();
            List<Plaats> aboPlaatsen = new List<Plaats>();
            List<Stadion> stadions = new List<Stadion>();
            List<Stadion> aboStadions = new List<Stadion>();
            for (int i = 0; i < bestellijnen.Count(); i++)
            {
                if (bestellijnen.ElementAt(i).aboID != null)
                {
                    abos.Add(aservice.getAboByID(bestellijnen.ElementAt(i).aboID.Value));
                    aboPloegen.Add(plservice.getPloegByID(aservice.getAboByID(bestellijnen.ElementAt(i).aboID.Value).ploegID));
                    aboPlaatsen.Add(pservice.getPlaatsByID(aservice.getAboByID(bestellijnen.ElementAt(i).aboID.Value).plaatsID));
                    aboStadions.Add(staservice.getStadionByID(plservice.getPloegByID(aservice.getAboByID(bestellijnen.ElementAt(i).aboID.Value).ploegID).stadionID));
                       
                }
                else
                {
                    thuisPloegen.Add(plservice.getPloegByID(wservice.getWedstrijdByID(tservice.getTicketByID(bestellijnen.ElementAt(i).ticketID.Value).wedstrijdID).thuisID));
                    uitPloegen.Add(plservice.getPloegByID(wservice.getWedstrijdByID(tservice.getTicketByID(bestellijnen.ElementAt(i).ticketID.Value).wedstrijdID).uitID));
                    prijzen.Add(prservice.getPriceByID(tservice.getTicketByID(bestellijnen.ElementAt(i).ticketID.Value).PrijsID));
                    plaatsen.Add(pservice.getPlaatsByID(prservice.getPriceByID(tservice.getTicketByID(bestellijnen.ElementAt(i).ticketID.Value).PrijsID).plaatsID));
                    stadions.Add(staservice.getStadionByID(plservice.getPloegByID(wservice.getWedstrijdByID(tservice.getTicketByID(bestellijnen.ElementAt(i).ticketID.Value).wedstrijdID).thuisID).stadionID));

                }
            }
            vm.thuisPloegen = thuisPloegen;
            vm.uitploegen = uitPloegen;
            vm.AbonnementPloeg = aboPloegen;
            vm.AbonnementPlaatsen = aboPlaatsen;
            vm.Plaatsen = plaatsen;
            vm.Prijzen = prijzen;
            vm.Abonnementen = abos;
            vm.Stadions = stadions;
            vm.AbonnementStadions = aboStadions;
            return View(vm);

        }
        private string placeLeft(int[] AmountPerPlace, Wedstrijd wedstrijd)
        {
            Ploeg thuisploeg = plservice.getPloegByID(wedstrijd.thuisID);
            Stadion stadion = staservice.getStadionByID(thuisploeg.stadionID);
            IEnumerable<Abo> abonnementenVanThuisPloeg = aservice.getAbosByPloeg(thuisploeg.ploegID);
            IEnumerable<Ticket> TicketsVanWedstrijd = tservice.getTicketByWedstrijd(wedstrijd.wedstrijdID);
            int ORT, ORB, ORO, ORW, BRT, BRB, BRO, BRW;
            ORT = stadion.ORT;
            ORB = stadion.ORB;
            ORO = stadion.ORO;
            ORW = stadion.ORW;
            BRT = stadion.BRT;
            BRB = stadion.BRB;
            BRO = stadion.BRO;
            BRW = stadion.BRW;
            for (int i = 0; i < abonnementenVanThuisPloeg.Count(); i++)
            {
                switch (abonnementenVanThuisPloeg.ElementAt(i).plaatsID)
                {
                    case 1:
                        ORT--;
                        break;
                    case 2:
                        ORB--;
                        break;
                    case 3:
                        ORO--;
                        break;
                    case 4:
                        ORW--;
                        break;
                    case 5:
                        BRT--;
                        break;
                    case 6:
                        BRB--;
                        break;
                    case 7:
                        BRO--;
                        break;
                    case 8:
                        BRW--;
                        break;
                }

            }

            for (int i = 0; i < TicketsVanWedstrijd.Count(); i++)
            {
                Prijs prijs = prservice.getPriceByID(TicketsVanWedstrijd.ElementAt(i).PrijsID);
                switch (prijs.plaatsID) {
                    case 1:
                        ORT--;
                        break;
                    case 2:
                        ORB--;
                        break;
                    case 3:
                        ORO--;
                        break;
                    case 4:
                        ORW--;
                        break;
                    case 5:
                        BRT--;
                        break;
                    case 6:
                        BRB--;
                        break;
                    case 7:
                        BRO--;
                        break;
                    case 8:
                        BRW--;
                        break;
                }
            }
            ORT -= AmountPerPlace[0];
            ORB -= AmountPerPlace[1];
            ORO -= AmountPerPlace[2];
            ORW -= AmountPerPlace[3];
            BRT -= AmountPerPlace[4];
            BRB -= AmountPerPlace[5];
            BRO -= AmountPerPlace[6];
            BRW -= AmountPerPlace[7];
            string responsetext = "Volgende plaatsen zijn uitverkocht: ";
            if (ORT < 0)
            {
                responsetext += "Onderste ring achter het doel thuisploeg, ";
            }
            if (ORB < 0)
            {
                responsetext += "Onderste ring achter het doel bezoekers, ";
            }
            if (ORO < 0)
            {
                responsetext += "Onderste ring zijlijn Oost, ";
            }
            if (ORW < 0)
            {
                responsetext += "Onderste ring zijlijn West, ";
            }
            if (BRT < 0)
            {
                responsetext += "Bovenste ring achter het doel thuisploeg, ";
            }
            if (BRB < 0)
            {
                responsetext += "Bovenste ring achter het doel bezoekers, ";
            }
            if (BRO < 0)
            {
                responsetext += "Bovenste ring achter  zijlijn Oost, ";
            }
            if (BRW < 0)
            {
                responsetext += "Bovenste ring achter  zijlijn West, ";
            }
            return responsetext;
        }
    }
}
using InvoiceAPP.Models.Invoice;

namespace InvoiceAPP.Data
{
    public static class InvoiceStore
    {
        public static  List<Invoice> invoiceList = new List<Invoice>
        {
          //  string invoiceId,  string ownerId, Address billFrom, CustomerInfo billTo, ProjectInfo projectInfo, List<Item> itemList, Status status
                new Invoice(
                            "XG1234", 
                    "11", 
                    new Address("Rustaveli", "Tbilisi", "QWE12 PD3", "Tbilisi"),
                      new CustomerInfo("Nick", "cafe@gmail.com", new Address("Mardjanishvili", "Tbilsi", "QW21R", "Tbilisi")),
                            new ProjectInfo(DateTime.Today, 45, "Baris Magidebu"),
                            new List<Item>{new Item("Magida #1", 3, 40.0), new Item("Magida #2", 4, 30.0)},
                            Invoice.Status.PAID),
                new Invoice("ZW4349", 
                    "12", 
                    new Address("Tsereteli", "Tbilisi", "STE56 PR4", "Tbilisi"),
                    new CustomerInfo("David", "building@gmail.com", new Address("Chavchavadze", "Tbilsi", "QW21R", "Tbilisi")),
                    new ProjectInfo(DateTime.Today, 45, "Ciklovka"),
                    new List<Item>{new Item("Iatakis laqi", 5, 10.0), new Item("Rastvariweli", 2, 20.0)},
                    Invoice.Status.DRAFT),
        };
    }
}


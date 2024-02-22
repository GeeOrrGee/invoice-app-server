using AutoMapper;
using InvoiceAPP.Models.DTO;
using InvoiceAPP.Models.Repositories;
using InvoiceAPP.Models.Services;

namespace InvoiceAPP.Models
{
    public class InvoiceService : IService
    {
        private readonly ItemRepository _itemRepository;
        private readonly AddressRepository _addresrepository;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(ItemRepository itemRepository, AddressRepository addressRepository, InvoiceRepository repository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _addresrepository = addressRepository;
            _invoiceRepository = repository;
            _mapper = mapper;
        }

        public bool CreateDraft(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO != null && invoiceDTO.Status.ToUpper() == "DRAFT")
            {
                var billfromadressDto = invoiceDTO.billFromAddress;
                var clientaddressDto = invoiceDTO.ClientAddress;

                var billFromAddress = new AdressEntity()
                {
                    country = billfromadressDto.Country,
                    city = billfromadressDto.City,
                    streetAdress = billfromadressDto.StreetAddress,
                    postCode = billfromadressDto.PostCode
                };

                var clientaddress = new AdressEntity()
                {
                    country = billfromadressDto.Country,
                    city = billfromadressDto.City,
                    streetAdress = billfromadressDto.StreetAddress,
                    postCode = billfromadressDto.PostCode
                };
                _addresrepository.Create(billFromAddress);
                _addresrepository.Create(clientaddress);
                var invoice = new InvoiceEntity()
                {
                    billFromAddressID = billFromAddress.Id,
                    clientName = invoiceDTO.ClientName,
                    clientEmail = invoiceDTO.ClientEmail,
                    clientAdressID = clientaddress.Id,
                    createDate = invoiceDTO.CreateTime,
                    projectDescription = invoiceDTO.ProjectDescription,
                    Status = invoiceDTO.Status
                };
                _invoiceRepository.Create(invoice);
                var itemDtoList = invoiceDTO.Items;
                foreach (var itemDto in itemDtoList)
                {
                    var item = new ItemEntity()
                    {
                        Name = itemDto.Name,
                        Quantity = itemDto.Quantity,
                        Price = itemDto.Price,
                        invoiceID = invoice.ID
                    };
                    _itemRepository.Create(item);
                }
                return true;
            }
            throw new ArgumentNullException();
        }

        public bool CreatePending(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO != null && invoiceDTO.Status.ToUpper() == "PENDING")
            {
                var billfromadressDto = invoiceDTO.billFromAddress;
                var clientaddressDto = invoiceDTO.ClientAddress;

                var billFromAddress = new AdressEntity()
                {
                    country = billfromadressDto.Country,
                    city = billfromadressDto.City,
                    streetAdress = billfromadressDto.StreetAddress,
                    postCode = billfromadressDto.PostCode
                };

                var clientaddress = new AdressEntity()
                {
                    country = billfromadressDto.Country,
                    city = billfromadressDto.City,
                    streetAdress = billfromadressDto.StreetAddress,
                    postCode = billfromadressDto.PostCode
                };
                _addresrepository.Create(billFromAddress);
                _addresrepository.Create(clientaddress);
                var invoice = new InvoiceEntity()
                {
                    billFromAddressID = billFromAddress.Id,
                    clientName = invoiceDTO.ClientName,
                    clientEmail = invoiceDTO.ClientEmail,
                    clientAdressID = clientaddress.Id,
                    createDate = invoiceDTO.CreateTime,
                    projectDescription = invoiceDTO.ProjectDescription,
                    Status = invoiceDTO.Status
                };
                _invoiceRepository.Create(invoice);
                var itemDtoList = invoiceDTO.Items;
                foreach (var itemDto in itemDtoList)
                {
                    var item = new ItemEntity()
                    {
                        Name = itemDto.Name,
                        Quantity = itemDto.Quantity,
                        Price = itemDto.Price,
                        invoiceID = invoice.ID
                    };
                    _itemRepository.Create(item);
                }
                return true;
            }
            throw new ArgumentNullException();
        }

        public void DeleteInvoice(string invoiceID)
        {
            if (invoiceID != null)
            {
                _invoiceRepository.Delete(invoiceID);
            }
            throw new ArgumentNullException("Invoice with this Id does not exist!");
        }

        public void UpdateInvoice(InvoiceDTO invoiceDTO)
        {
            var invoice = _invoiceRepository.GetById(invoiceDTO.InvoiceId);
            invoice.Status = invoiceDTO.Status;
            invoice.clientEmail = invoiceDTO.ClientEmail;
            invoice.clientName = invoiceDTO.ClientName;
            invoice.paymentTerm = invoiceDTO.PaymentTerm;
            invoice.projectDescription = invoiceDTO.ProjectDescription;
            _invoiceRepository.Update(invoice);
        }

        public InvoiceDTO GetinvoiceID(string invoiceID)
        {
            if (invoiceID != null)
            {
                var invoice = _invoiceRepository.GetById(invoiceID);
                var billFromAddress = _addresrepository.GetById(invoice.billFromAddressID);
                var billFromAddressDto = new AddressDTO()
                {
                    Country = billFromAddress.country,
                    City = billFromAddress.city,
                    StreetAddress = billFromAddress.streetAdress,
                    PostCode = billFromAddress.postCode
                };

                var clientAddress = _addresrepository.GetById(invoice.clientAdressID);
                var clientAddressDto = new AddressDTO()
                {
                    Country = clientAddress.country,
                    City = clientAddress.city,
                    StreetAddress = clientAddress.streetAdress,
                    PostCode = clientAddress.postCode
                };

                var itemList = _itemRepository.GetList(invoice.ID).ToList();
                var itemListDto = new List<ItemDTO>();
                foreach (var item in itemList)
                {
                    var itemDto = new ItemDTO()
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    itemListDto.Add(itemDto);
                }

                var invoiceDto = new InvoiceDTO()
                {
                    ClientName = invoice.clientName,
                    ClientEmail = invoice.clientEmail,
                    CreateTime = invoice.createDate,
                    PaymentTerm = invoice.paymentTerm,
                    Status = invoice.Status,
                    billFromAddress = billFromAddressDto,
                    ClientAddress = clientAddressDto,
                    Items = itemListDto
                };
                return invoiceDto;
            }
            throw new ArgumentNullException("Invoice with this Id does not exist");
        }

        public IEnumerable<InvoiceDTO> GetinvoiceList()
        {
            var invoiceList = _invoiceRepository.GetList().ToList();
            var invoiceDtolist = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                var billFromAddress = _addresrepository.GetById(invoice.billFromAddressID);
                var billFromAddressDto = new AddressDTO()
                {
                    Country = billFromAddress.country,
                    City = billFromAddress.city,
                    StreetAddress = billFromAddress.streetAdress,
                    PostCode = billFromAddress.postCode
                };

                var clientAddress = _addresrepository.GetById(invoice.clientAdressID);
                var clientAddressDto = new AddressDTO()
                {
                    Country = clientAddress.country,
                    City = clientAddress.city,
                    StreetAddress = clientAddress.streetAdress,
                    PostCode = clientAddress.postCode
                };

                var itemList = _itemRepository.GetList(invoice.ID).ToList();
                var itemListDto = new List<ItemDTO>();
                foreach (var item in itemList)
                {
                    var itemDto = new ItemDTO()
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    itemListDto.Add(itemDto);
                }

                var invoiceDto = new InvoiceDTO()
                {
                    ClientName = invoice.clientName,
                    ClientEmail = invoice.clientEmail,
                    CreateTime = invoice.createDate,
                    PaymentTerm = invoice.paymentTerm,
                    Status = invoice.Status,
                    billFromAddress = billFromAddressDto,
                    ClientAddress = clientAddressDto,
                    Items = itemListDto
                };
                invoiceDtolist.Add(invoiceDto);
            }
            return invoiceDtolist;
        }

        public IEnumerable<InvoiceDTO> GetinvoiceListByStatus(string status)
        {
            var invoiceList = _invoiceRepository.GetListByStatus(status).ToList();
            var invoiceDtolist = new List<InvoiceDTO>();
            foreach (var invoice in invoiceList)
            {
                var billFromAddress = _addresrepository.GetById(invoice.billFromAddressID);
                var billFromAddressDto = new AddressDTO()
                {
                    Country = billFromAddress.country,
                    City = billFromAddress.city,
                    StreetAddress = billFromAddress.streetAdress,
                    PostCode = billFromAddress.postCode
                };

                var clientAddress = _addresrepository.GetById(invoice.clientAdressID);
                var clientAddressDto = new AddressDTO()
                {
                    Country = clientAddress.country,
                    City = clientAddress.city,
                    StreetAddress = clientAddress.streetAdress,
                    PostCode = clientAddress.postCode
                };

                var itemList = _itemRepository.GetList(invoice.ID).ToList();
                var itemListDto = new List<ItemDTO>();
                foreach (var item in itemList)
                {
                    var itemDto = new ItemDTO()
                    {
                        Name = item.Name,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    itemListDto.Add(itemDto);
                }

                var invoiceDto = new InvoiceDTO()
                {
                    ClientName = invoice.clientName,
                    ClientEmail = invoice.clientEmail,
                    CreateTime = invoice.createDate,
                    PaymentTerm = invoice.paymentTerm,
                    Status = invoice.Status,
                    billFromAddress = billFromAddressDto,
                    ClientAddress = clientAddressDto,
                    Items = itemListDto
                };
                invoiceDtolist.Add(invoiceDto);
            }
            return invoiceDtolist;
        }

        public bool MarkAsPaid(string invoiceid)
        {
            if (invoiceid != null)
            {
                var invoice = _invoiceRepository.GetById(invoiceid);
                invoice.Status = "PAID";
                _invoiceRepository.Update(invoice);
                return true;
            }
            return false;
        }
    }
}

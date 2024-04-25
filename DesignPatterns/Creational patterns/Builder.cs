// public class Person
// {
//     // address
//     public string StreetAddress, Postcode, City;
//
//     // employment
//     public string CompanyName, Position;
//     public int AnnualIncome;
//
//     public override string ToString()
//     {
//         return
//             $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
//     }
// }
//
// public class PersonBuilder // fasada
// {
//     // prenosi se po referenci, za vrednosne tipove bi morale neke modifikacije ( ref? )
//     protected Person person = new Person(); 
//     public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
//     public PersonJobBuilder Works => new PersonJobBuilder(person);
//     
//     // sa implicit dajemo kompajelu dozvolu da automatski kastuje u nas tip
//     // dole u main metodi ako stavimo var person = personBuilder. ... person ce biti tipa PersonJobBuilder ( zasto ne PersonAddressBuilder - zato sto gleda ono sto je poslednje pozvano
//     // ako zamenim mesta pozivima Lives i Works onda ce biti PersonJobBuilder tip) 
//     // ali ako stavimo Person person = personBuilder. ... person ce stvarno biti tipa Person
//     public static implicit operator Person(PersonBuilder pb)
//     {
//         return pb.person;
//     }
// }
//
// public class PersonJobBuilder : PersonBuilder
// {
//     public PersonJobBuilder(Person person)
//     {
//         this.person = person;
//     }
//
//     public PersonJobBuilder At(string companyName)
//     {
//         person.CompanyName = companyName;
//         return this;
//     }
//
//     public PersonJobBuilder AsA(string position)
//     {
//         person.Position = position;
//         return this;
//     }
//
//     public PersonJobBuilder Earning(int annualIncome)
//     {
//         person.AnnualIncome = annualIncome;
//         return this;
//     }
// }
//
// public class PersonAddressBuilder : PersonBuilder
// {
//     public PersonAddressBuilder(Person person)
//     {
//         this.person = person;
//     }
//
//     public PersonAddressBuilder At(string streetAddress)
//     {
//         person.StreetAddress = streetAddress;
//         return this;
//     }
//
//     public PersonAddressBuilder WithPostcode(string postcode)
//     {
//         person.Postcode = postcode;
//         return this;
//     }
//
//     public PersonAddressBuilder In(string city)
//     {
//         person.City = city;
//         return this;
//     }
// }
//
//
// class Builder
// {
//     static void Main(string[] args)
//     {
//         var pb = new PersonBuilder();
//         var person = pb
//             .Lives
//             .At("123 London Road")
//             .In("London")
//             .WithPostcode("SW12BC")
//             .Works
//             .At("Fabrikam")
//             .AsA("Engineer")
//             .Earning(123000);
//
//         Console.WriteLine(person);
//
//
//
//         // MarkingHeader mh = new MarkingHeader();
//         // mh.WithRegistrations("123", "456");
//         // Console.WriteLine(mh);
//
//         // MarkingHeaderBuilder mb = new MarkingHeaderBuilder();
//         // MarkingHeader markingHeader = mb.Registration.WithRegistrations("123", "456");
//         // Console.WriteLine(markingHeader);
//     }
// }
//
// // Recimo markiranje sa sgs-a - negde smo u sistemu hteli da napravimo objekat inicijirajuci registracije
// public class MarkingHeader
// {
//     public string frontRegistration, backRegistration;
//     public decimal markerQuantity, virtualNet;
//     
//     // mozemo reci ovde 
//     // public MarkingHeader WithRegistrations(string front, string back)
//     // {
//     //     frontRegistration = front;
//     //     backRegistration = back;
//     //     return this;
//     // }
//     // i sada u drugim delovima sistema mozemo reci ( linija 106 107 ) 
//     
//     // ovo se moze tumaciti kao krsenje Single Responsibility Principle pa ima i opcija sa izdvojenim ovim metodama 
//     // u odvojene klase. Takodje se moze koristiti opet ako ima vise klasa slicne logike kreiranja objekta
//     
//     // generalno ok je koristiti i u okviru klase ako zadovoljava potrebe
//
//     public override string ToString()
//     {
//         return $"{nameof(frontRegistration)}: {frontRegistration}, {nameof(backRegistration)}: {backRegistration}, {nameof(markerQuantity)}: {markerQuantity}, {nameof(virtualNet)}: {virtualNet}";
//     }
// }
//
// public class MarkingHeaderBuilder 
// {
//     protected MarkingHeader markingHeader = new MarkingHeader(); 
//     public MarkingRegistrationBuilder Registration => new MarkingRegistrationBuilder(markingHeader);
//    
//     public static implicit operator MarkingHeader(MarkingHeaderBuilder mhb)
//     {
//         return mhb.markingHeader;
//     }
// }
//
// public class MarkingRegistrationBuilder : MarkingHeaderBuilder
// {
//     public MarkingRegistrationBuilder(MarkingHeader markingHeader)
//     {
//         this.markingHeader = markingHeader;
//     }
//
//     public MarkingRegistrationBuilder WithRegistrations(string front, string back)
//     {
//         markingHeader.frontRegistration = front;
//         markingHeader.backRegistration = back;
//         return this;
//     }
// }
//

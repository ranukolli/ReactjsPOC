using System.Collections.Generic;
using System.Linq;
using Search;

namespace PeopleSearch.DAL
{

    public interface IsearchData
    {
       List<SearchModel> GetPersonDetails(string filter);
    }
    public class SearchData : IsearchData    
    {
    private PeopleSearchEntities _db;
    public SearchData()
    {

    }
    public SearchData(PeopleSearchEntities db)
    {
        _db = db;
    }


    public List<SearchModel> PersonList()
    {
            List<SearchModel> people = new List<SearchModel>();
            people.Add(
                        new SearchModel
                        {
                            PersonId = 1234,
                            FirstName = "Danny",
                            LastName = "Aguilar",
                            Title = "Manager",
                            Manager = "James Fike"
                        }
                      );
            people.Add(
                        new SearchModel
                        {
                            PersonId = 2222,
                            FirstName = "Ranadheer",
                            LastName = "Kolli",
                            Title = "Software Engineer",
                            Manager = "Danny Aguilar"
                        }
                       );
            people.Add(
                    new SearchModel
                    {
                        PersonId = 3333,
                        FirstName = "Ray",
                        LastName = "Loveless",
                        Title = "Software Engineer",
                        Manager = "Danny Aguilar"
                    }
                );

            people.Add(
                  new SearchModel
                  {
                      PersonId = 4444,
                      FirstName = "Jeff",
                      LastName = "Arrowsmith",
                      Title = "Software Engineer",
                      Manager = "Danny Aguilar"
                  }
              );
            people.Add(
                  new SearchModel
                  {
                      PersonId = 5555,
                      FirstName = "Michael",
                      LastName = "Rentmeister",
                      Title = "Software Engineer",
                      Manager = "Danny Aguilar"
                  }
              );

            return people;

    }
    public List<SearchModel> GetPersonDetails(string filter)
        {
            List<SearchModel> details = new List<SearchModel>();

            if (_db == null)
            {
                _db = new PeopleSearchEntities();
            }

            //var details = (from pd in _db.PersonDetails
            //               join p in _db.Pictures on pd.PersonId equals p.PersonId
            //               where (pd.FirstName.Contains(filter) || pd.LastName.Contains(filter))
            //               select new SearchModel
            //               {
            //                   PersonId = pd.PersonId,
            //                   FirstName = pd.FirstName,
            //                   LastName = pd.LastName,
            //                   Age = pd.Age,
            //                   Address = pd.Address,
            //                   Interests = pd.Interests,
            //                   Image = p.Picture1
            //               }).ToList();

            List<SearchModel> people = PersonList();

            foreach(var item in people)
            {
                if(item.FirstName.ToLower().Contains(filter) || item.LastName.ToLower().Contains(filter))
                {
                    details.Add(item);
                }
                  
            }

            return details;

        }
    }
}
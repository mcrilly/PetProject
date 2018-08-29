using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PetProject.Enums;
using PetProject.Models;

namespace PetProject.Services
{
    public class PetService : IPetService
    {
        /// <summary>
        /// Return all the owners and their pet list
        /// </summary>
        /// <returns></returns>
        public List<OwnerDetail> GetAllOwners()
        {
            return LoadOwnerDetailFile();
        }


        /// <summary>
        /// Return gender of owners that have the requested petType, and only return those pets matching the pet type
        /// </summary>
        /// <param name="petType"></param>
        /// <returns></returns>
        public List<PetNamesByOwnerGender> GetOwnersWithPetType(PetType petType)
        {
            var results = new List<PetNamesByOwnerGender>();

            // deserialise json into typed collection
            var petDetails = LoadOwnerDetailFile();

            if (petDetails != null && petDetails.Any())
            {
                // get pet owners and pets from the list
                foreach (var detail in petDetails.Where(x => x.Pets != null && x.Pets.Any(y => y.Type == petType)))
                {
                    // initialise variable
                    PetNamesByOwnerGender newPetNamesByGender;

                    // if this gender is already present, then retrieve it
                    if (results.Exists(x => string.Equals(x.Gender, detail.Gender.ToString(),
                        StringComparison.InvariantCultureIgnoreCase)))
                    {
                        newPetNamesByGender = results.Find(x => string.Equals(x.Gender, detail.Gender.ToString(),
                            StringComparison.InvariantCultureIgnoreCase));
                    }
                    else
                    {
                        // create a new gender record for pet names
                        newPetNamesByGender = new PetNamesByOwnerGender
                        {
                            Gender = detail.Gender.ToString(),
                            PetNames = new List<string>()
                        };
                        results.Add(newPetNamesByGender);
                    }

                    // add the new pet names to the list
                    newPetNamesByGender.PetNames.AddRange(detail.Pets.Where(y => y.Type == petType).Select(y => y.Name));
                }
            }

            return results;
        }


        /// <summary>
        /// Read in the json file with the list of owners and their pets
        /// </summary>
        /// <returns></returns>
        private static List<OwnerDetail> LoadOwnerDetailFile()
        {
            var response = new List<OwnerDetail>();
            try
            {
                // read in file content
                var myFilePath = Path.Combine(Path.GetDirectoryName(
                  System.Reflection.Assembly.GetExecutingAssembly().Location), @"Data\Pet.json");
                var fileContent = File.ReadAllText(myFilePath);
                if (!string.IsNullOrEmpty(fileContent))
                {
                    // parse the file and return the collection
                    return JsonConvert.DeserializeObject<List<OwnerDetail>>(fileContent);
                }
            }
            catch (Exception e)
            {
                // there has been a problem
                Console.WriteLine(e);
                throw;
            }

            return response;
        }
    }
}

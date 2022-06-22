using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace pizza_mama.Models
{
    public class Pizza
    {
        //ignorer l id dans le fichier json
        [JsonIgnore]
        public int PizzaID { get; set; }
        [Display(Name = "Nom")]
        public string nom { get; set; }
        [Display(Name = "Prix")]
        public float prix { get; set; }
        [Display(Name = "Végétarien")]
        public bool vegetarienne { get; set; }
        [JsonIgnore]
        [Display(Name = "Ingrédients")]
        public string ingredients { get; set; }
        //Ignorer pour ne pas l ajouter dans la bas e de donées
        [NotMapped]
        [JsonPropertyName("Ingredients")]
        public string[] listeIngredients
        {
            get
            {
                if(ingredients == null || ingredients.Count() == 0)
                {
                    return null;
                }
                return ingredients.Split(", ");
            
            }
        }
       
    }
}

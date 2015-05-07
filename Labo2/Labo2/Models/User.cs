using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Labo2.Models
{
   public class User : Labo2.Class.SqlExpressWrapper
   {
      public int Id { get; set; }
      [Required(ErrorMessage="Le prenom est obligatoire")]
      public string Prenom { get; set; }
      [Required(ErrorMessage = "Le nom est obligatoire")]
      public string Nom { get; set; }
      public string Telephone { get; set; }
      [Display(Name="Code Postal")]
      public string Code_Postal { get; set; }
      [DataType(DataType.Date, ErrorMessage="Pas une date valide")]
      public DateTime Naissance { get; set; }
      public int Sexe { get; set; }
      [Display(Name="État Civil")]
      public int Etat_Civil { get; set; }
      public string Picture { get; set; }

      public User(Object connexionString)
         : base(connexionString)
      {
         SQLTableName = "USERS";
      }

      public User()
         : base("")
      {
      }
      public override void GetValues()
      {
         Id = int.Parse(this["ID"]);
         Prenom = this["PRENOM"];
         Nom = this["NOM"];
         Telephone = this["TELEPHONE"];
         Code_Postal = this["CODE_POSTAL"];
         Naissance = DateTime.Parse(this["NAISSANCE"]);
         Sexe = int.Parse(this["SEXE"]);
         Etat_Civil = int.Parse(this["ETAT_CIVIL"]);
         Picture = this["PICTURE"];
      }

      public String GetAvatarURL()
      {
         String url;
         if (String.IsNullOrEmpty(Picture))
         {
            url = @"Images/anonymous.jpg";
         }
         else
         {
            url = @"Avatars/" + Picture + ".png";
         }

         return url;
      }
      public override void Insert()
      {
         InsertRecord(Prenom, Nom, Telephone, Code_Postal, Naissance, Sexe, Etat_Civil, Picture);
      }
      public override void Update()
      {
         UpdateRecord(Id, Prenom, Nom, Telephone, Code_Postal, Naissance, Sexe, Etat_Civil, Picture);
      }
   }
}
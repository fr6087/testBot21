using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.FormOrder
{
    using Microsoft.Bot.Builder.FormFlow;

    // The trainingForm class represents the form that you want to complete 
    // using information that is collected from the user. 
    // It must be serializable so the bot can be stateless. 
    // The order of fields defines the default sequence in which the user is asked questions.

    // The enumerations define the valid options for each field in SandwichOrder, and the order
    // of the values represents the sequence in which they are presented to the user in a conversation.
    
        public enum CompanyOptions { Keine, companyName, function, givenName, surName, email, telephone, fax };

        public enum AdressOptions { Unbekannt, Frau, Herr };

        public enum ClusterOptions
        {
            Unbekannt, Energietechnik, Gesundheitswirtschaft, IKT_Medienkreativwirtschaft, Verkehr_Mobilität, Optik, Ernährungswirtschaft, Kunststoffe_Chemie, Metall, Tourismuswirtschaft
        };

        public enum RWKOptions
        {
            Unbekannt, Brandenburg_an_der_Havel, Cottbus, Eberswalde, Eisenhüttenstadt, Frankfurt_Oder, Luckenwalde,
            Ludwigsfelde, Neuruppin, O_H_V, Potsdam, Prignitz, Schönefelderkreuz, Spremberg, Schwendt_Oder, Westlausitz
        };

        [Serializable]
        public class FormOrder
        {
        [Prompt("Was ist der {&} deiner Firma? {||}")] //, ChoiceFormat = "{1}")]
            public String name;
        [Prompt("Wie heißt der {&} deiner Firma? {||}")]
        public String Projektverantwortliche;
        [Prompt("Bitte nenne mir seine {&}. {||}")]
        public String Telefonnummer;
        [Prompt("Bitte nenne mir seine {&}. {||}")]
        public String Faxnummer;

        public ClusterOptions Cluster;
            public RWKOptions RWK;
            
            public AdressOptions Adress;
            public List<CompanyOptions> Company;

            public static IForm<FormOrder> BuildForm()
            {
            return new FormBuilder<FormOrder>()
                        .Message("Welcome to the simple form assistant bot!")
                        .Build();
            }
        };
    
    
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelEditierenViewModel : ObservableValidator, IStempelEditierenViewModel
    {
        private IXMLConverter.IXMLConverter converter;
        IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        private string tb_guid;
        [CustomValidation(typeof(StempelEditierenViewModel), nameof(checkGuid))]
        public string Tb_guid
        {
            get => tb_guid;
            set
            {
                if (SetProperty(ref this.tb_guid, value, true))
                {
                    SpeichernCommand.NotifyCanExecuteChanged();
                }
            }

        }

        [ObservableProperty]
        string? tb_name;
        [ObservableProperty]
        bool erstellinformationen;
        [ObservableProperty]
        bool aufgabeErzeugen;
        [ObservableProperty]
        Color farbe;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(SpeichernCommand))]
        //[CustomValidation(typeof(StempelEditierenViewModel),nameof(checkBeschreibung))]
        //string? rtb_beschreibung;

        private string rtb_beschreibung;
        [CustomValidation(typeof(StempelEditierenViewModel), nameof(checkBeschreibung))]
        public string Rtb_beschreibung
        {
            get => rtb_beschreibung;
            set
            {
                if (SetProperty(ref this.rtb_beschreibung, value, true))
                {
                    SpeichernCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public StempelEditierenViewModel(IXMLConverter.IXMLConverter converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException("IStempelViewModel Interface null");
            }
            this.converter = converter;
        }
        [RelayCommand]
        public void Neu()
        {
            clear();
        }
        [RelayCommand]
        public void Abbrechen()
        {
            
        }

        [RelayCommand(CanExecute = nameof(checkAllValues))]
        public void Speichern()
        {
            
        }
        private void clear()
        {
            Tb_guid = "";
            Tb_name = "";
            Erstellinformationen = false;
            AufgabeErzeugen = false;
            Farbe = ColorTranslator.FromHtml("#FF247835");
            Rtb_beschreibung = "";
        }
        public Stempelverfuegung GetStempelverfuegung()
        {
            Guid guid = Guid.Parse(Tb_guid);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Rtb_beschreibung);
            return new Stempelverfuegung(guid, Tb_name, Erstellinformationen, Farbe, AufgabeErzeugen, doc);
        }
        private bool checkAllValues()
        {
            ValidateAllProperties();
            return !HasErrors;
        }
        public static ValidationResult checkGuid(string guid, ValidationContext context)
        {
            if (String.IsNullOrEmpty(guid))
            {
                return new ValidationResult("GUID darf nicht leer sein");
            }
            else
            {
                try
                {
                    Guid.Parse(guid);
                    return ValidationResult.Success!;
                }
                catch (Exception)
                {
                    return new ValidationResult("GUID ist nicht im richtigen Format");
                }
            }
        }
        public static ValidationResult checkBeschreibung(string beschreibung, ValidationContext context)
        {
            //write method to convert string beschreibung to XMLDocument
            try
            {
                
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(beschreibung);
                return ValidationResult.Success!;
            }
            catch (Exception)
            {
                return new ValidationResult("Beschreibung ist nicht im richtigen Format");
            }
        }
    }
}

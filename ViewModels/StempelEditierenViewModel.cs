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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ViewModelsInterfaces;

namespace ViewModels
{
    public partial class StempelEditierenViewModel : ObservableValidator, IStempelEditierenViewModel
    {
        private IXMLConverter.IXMLConverter converter;
        //private IStorage.IStorageService storageService;
        //IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        [ObservableProperty]
        string tb_guid_errormessage;
        private string tb_guid;
        [CustomValidation(typeof(StempelEditierenViewModel), nameof(checkGuid))]        
        public string Tb_guid
        {
            get => tb_guid;
            set
            {
                if (SetProperty(ref this.tb_guid, value, true))
                {
                    Speichern_ClickCommand.NotifyCanExecuteChanged();
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

        [ObservableProperty]
        string rtb_beschreibung_errormessage;

        private string rtb_beschreibung;
        [CustomValidation(typeof(StempelEditierenViewModel), nameof(checkBeschreibung))]
        public string Rtb_beschreibung
        {
            get => rtb_beschreibung;
            set
            {
                if (SetProperty(ref this.rtb_beschreibung, value, true))
                {
                    Speichern_ClickCommand.NotifyCanExecuteChanged();
                }
            }
        }

        public event EventHandler StempelSpeichernEvent;
        public StempelEditierenViewModel(IXMLConverter.IXMLConverter converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException("Interfaces null");
            }
            this.converter = converter;            
        }


        [RelayCommand]
        public void Neu()
        {            
            clear();
            GeneriereGuid();
        }

        [RelayCommand(CanExecute = nameof(checkAllValues))]
        public void OnSpeichern_Click()
        {
            StempelEventArgs eventArgs = new StempelEventArgs();
            eventArgs.Stempelverfuegung = GetStempelverfuegung();
            
            EventHandler eventHandler = StempelSpeichernEvent;
            eventHandler?.Invoke(this, eventArgs);
        }
        [RelayCommand]
        public void GeneriereGuid()
        {
            Tb_guid = Guid.NewGuid().ToString();
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
            XElement beschreibungXml = converter.convertBeschreibungToXml(Rtb_beschreibung);
            return new Stempelverfuegung(guid, Tb_name, Erstellinformationen, Farbe, AufgabeErzeugen, beschreibungXml);
        }
        private bool checkAllValues()
        {
            ValidateAllProperties();
            updateErrorMessages();
            return !HasErrors;
        }
        private void updateErrorMessages()
        {
            try
            {
                Rtb_beschreibung_errormessage = GetErrors(nameof(Rtb_beschreibung)).First().ErrorMessage!;
            }
            catch
            {
                Rtb_beschreibung_errormessage = "";
            }
            try
            {
                Tb_guid_errormessage = GetErrors(nameof(Tb_guid)).First().ErrorMessage!;
            }
            catch
            {
                Tb_guid_errormessage = "";
            }
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
                    return new ValidationResult("GUID ist nicht im richtigen Format: 01234567-89AB-CDEF-0123-456789ABCDEF");
                }
            }
        }
        public static ValidationResult checkBeschreibung(string beschreibung, ValidationContext context)
        {
            if (String.IsNullOrEmpty(beschreibung))
            {
                return new ValidationResult("Beschreibung darf nicht leer sein");
            }
            else
            {                
                string pattern = @"/\{(.+?)\}"; // Regular expression to search for a pattern "/{X}" to check if X is an integer
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(beschreibung);
                bool success = true;                
                foreach(Match match in matches)
                {
                    string numberString = match.Value.TrimStart('/').TrimStart('{').TrimEnd('}');
                    if (int.TryParse(numberString, out int number))
                    {
                        // Valid integer found
                        return ValidationResult.Success!; ;
                    }
                    else
                    {
                        // Invalid expression or non-integer found
                        success = false;
                    }
                }
                if (success)
                {
                    return ValidationResult.Success!;
                }
                else
                {
                    return new ValidationResult("Platzhalter in der Beschreibung müssen im Format /{#} angegeben werden, wobei # die ID des Platzhalters ist. Beispiel '/{1}' für den Platzhalter mit der Id 1.");
                }
            }
        }

        public void fillStempelverfuegung(Stempelverfuegung stempelverfuegung)
        {
            Tb_guid = stempelverfuegung.Id.ToString();
            Tb_name = stempelverfuegung.Name;
            Erstellinformationen = stempelverfuegung.ErstellInformationenAnzeigen;
            AufgabeErzeugen = stempelverfuegung.AufgabeErzeugen;
            Farbe = stempelverfuegung.Farbe;
            //Rtb_beschreibung = converter.convertBeschreibungToXaml(stempelverfuegung.Beschreibung);
        }
    }
}

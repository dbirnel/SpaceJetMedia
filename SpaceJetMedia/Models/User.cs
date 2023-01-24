using System.Xml.Serialization;

namespace SpaceJetMedia.Models
{
    [Serializable]
    [XmlRoot("User")]
    public class User
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("ClientId")]
        public int ClientId { get; set; }
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Email")]
        public string Email { get; set; }
        [XmlElement("IsBusinessContact")]
        public bool IsBusinessContact { get; set; }
        [XmlElement("IsAccountingContact")]
        public bool IsAccountingContact { get; set; }
        [XmlElement("IsTechnicalContact")]
        public bool IsTechnicalContact { get; set; }
        [XmlElement("HasApiAccess")]
        public bool HasApiAccess { get; set; }
    }
}
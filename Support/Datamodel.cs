
public class Datamodel
{
    public int hostRef { get; set; }
    public string country { get; set; }
    public string eppoCode { get; set; }
    public Plantname[] plantName { get; set; }
    public string annexSixRule { get; set; }
    public string annexElevenRule { get; set; }
    public string outcome { get; set; }
    public Pestdetail[] pestDetails { get; set; }
    public Annex11rulesarr[] annex11RulesArr { get; set; }
    public string isEUSL { get; set; }
    public bool all { get; set; }
    public string subformat { get; set; }
    public string ProhibitionClarification { get; set; }
    public string FormatClarification { get; set; }
    public string hybridIndicator { get; set; }
    public string dormantIndicator { get; set; }
    public string seedIndicator { get; set; }
    public string fruitIndicator { get; set; }
    public string bonsaiIndicator { get; set; }
    public string invintroIndicator { get; set; }
}

public class Plantname
{
    public string type { get; set; }
    public object NAME { get; set; }
}

public class Pestdetail
{
    public int csl_ref { get; set; }
    public Name[] name { get; set; }
    public Format format { get; set; }
    public string quarantine_indicator { get; set; }
    public string regulated_indicator { get; set; }
    public string regulation_category { get; set; }
    public Pest_Country pest_country { get; set; }
}

public class Format
{
    public string FORMAT { get; set; }
    public string FORMAT_ID { get; set; }
}

public class Pest_Country
{
    public string COUNTRY_NAME { get; set; }
    public string COUNTRY_CODE { get; set; }
    public string STATUS { get; set; }
}

public class Name
{
    public string type { get; set; }
    public object NAME { get; set; }
}

public class Annex11rulesarr
{
    public string PLANT_LATIN_NAME { get; set; }
    public string PLANT_CHILDREN_HOST_REF { get; set; }
    public string PHI_PLANT_NAME { get; set; }
    public string FERA_PLANT_NAME { get; set; }
    public string EPPO_CODE { get; set; }
    public string HOST_REF { get; set; }
    public string COUNTRY_NAME { get; set; }
    public string COUNTRY_NAME_OLD { get; set; }
    public string A11_RULE { get; set; }
    public string INFERRED_INDICATOR { get; set; }
    public string SERVICE_FORMAT { get; set; }
    public string SERVICE_SUBFORMAT { get; set; }
    public string SERVICE_SUBFORMAT_EXCLUDED { get; set; }
    public string BTOM_CLARIFICATION { get; set; }
    public string BTOM_EUSL { get; set; }
    public string BTOM_NON_EUSL { get; set; }
}

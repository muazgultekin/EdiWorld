#	EdiWorld
Serializing and deserializing operation for any types of edi proccess 

##	EdiFileProccess Beta

An EDI file is a data file formatted using one of several Electronic Data Interchange (EDI) standards. It contains structured data stored in a plain text format and is used for transferring business data between multiple organizations. EDI files are designed to reduce errors, cost, and processing time associated with postal mail, email, and faxes.
EDI files may be saved in various standards. Several common EDI formats are listed below:
•	cXML
•	xCBL
•	ebXML
•	CSV
•	ANSI X12
•	EDIFACT
•	EDIFICE (Information Technology)
•	EDITRANS (Transportation)
•	ETIS (Telecommunications)
There are more than 300 edi file types.
The advantages for those working in the transport industry is that regular high-volume communications can be automated allowing dispatchers and accounts receivables staff more time to concentrate on more productive/profitable tasks and supply clients with much better customer care. One of the major benefits of EDI is that it gets rid of a dispatcher from having to by hand crucial information into the dispatch functional and billing system. This leads to saving money and time while getting rid of any pricey data entry mistakes. The other benefit is that transportation companies who are EDI certified can interact seamlessly and digitally with all celebrations in the supply chain process.
 

##	EDIFACT

EDIFACT stands for Electronic Data Interchange For Administration, Commerce, and Transport. The United Nations developed the EDIFACT. It finds use in multi-country/multi-industry trading purposes and in an overall global context. The companies in Europe have been using EDIFACT for a very long time. Hence, the EDIFACT finds broad use in the European parts. UNEDIFACT is another term that refers to EDIFACT.
VDA

VDA stands for Verband der Deutschen Automobilindustrie. It is the German automotive EDI standard. Widely used by the German Automobile companies for the transfer of their business documents, this EDI standard was very much popularized in Germany. Though they do not contain all the characteristics of a typical EDI message, the UK automobile supply industry accepted it.
ODETTE

The automotive industries in Europe developed the EDI standard ODETTE (The Organisation for Data Exchange by Tele Transmission in Europe). It came about to facilitate the exchange of EDI documents with their trading partners. The communication standards such as OFTP and OFTP2.0 came about due to the popularity of ODETTE.
EANCOM

EANCOM came about in 1987 as a subset to EDIFACT. At first, EANCOM was only for the retail industry. Later on, EANCOM was implemented in other areas as well such as health care and construction, etc. It soon became one of the most popular subsets of EDI due to its usage in various industries.
ANSI X12

The American National Standards Institute created the EDI format ANSI X12. The ANSI X12 is more popular compared to other EDI standards. This is because ANSI X12 covers a wide range of industries ranging from healthcare to retail to even the automotive industry. The use of ANSI X12 started in the North American region. The other regions of the world also make use of ANSI X12 now. 
HIPAA
This EDI standard enables secure transaction of records. The healthcare industry uses it primarily. It also enables access for the patients to their healthcare information. HIPAA stands for Health Insurance Portability and Accountability Act.
TRADACOMS

The TRADACOMs EDI Standard finds use in the domestic trading in the UK. The first version came about in 1982, and this EDI standard has some similarities with that of EDIFACT. In 1995, development of Tradacoms came to a halt. Yet the retail industry uses it even today.
The types of EDI mentioned above are the main ones profoundly used by most of the business industries around the world. There are other EDI standards too such as SWIFT, VICS, etc.  

##	EDI FILE PROCCESS SOLUTION (BETA)

In this project we developed an EDI framework. This framework will be supporting any type of EDI files. In this version this framework support ANSI X12 Edi format. In the coming version EDIFACT support will be added.
This framework is based on TAGs of Edi files. If you create you model correctly EdiFileProccess framework can serialize and deserialize the files easily.
Sample of EDI 990 Models


```csharp
[Edi(EdiType = EdiTypes.Edi990)]
public class Edi990Model : EdiModelBase
{               
	[EdiSegment(Path = "ST", Order = 2, IsCollection = true, SequenceEnd = "SE", IsWithSequenceEnd = true)]
	public List<ResponseToLoadTender> ResponseToLoadTenders { get; set; }        
}
```

After the 990 model is created, serializing and deserialize operation is handled easily.

Supported Models 	| Release Date 	| Serialization | Deserialization | Source document
------------------- | ------------- | ------------- | --------------- | ---------------
Edi997 				| 2019-11-07   	| Yes           | Yes             |


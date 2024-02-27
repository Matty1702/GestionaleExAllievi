# GestionaleExAllievi
documentazione\GestionaleExAllievi.md 2024-04-01

**Documentazione per registro di ex allievi** Introduzione

Il software deve essere in grado di gestire tutte le informazioni sugli ex allievi presenti nell' archivio, con lo scopo di aiutare una scuola a presentare statistiche dei propri studenti usciti dall' istituto, di seguito le principali funzioni e i requisiti hardware o software

Principali funzionalità

Il software che viene presentato avrà come principali caratteristiche le seguenti:

- **Accesso e autenticazione**: per gli utenti del sito, un login sicuro e una divisione tra gli utenti normali e gli amministratori
- **Registrazione ex allievi**: gli allievi usciti dall' istituto devono potersi registrare nella piattaforma, con dati anagrafici, accademici/lavorativi e descrittivi
- **Gestione informazioni**: per gli amministratori dell' applicazione, una sezione di gestione, visione e modifica delle informazioni dei diversi allievi e delle aziende
- **Ricerca**: la scuola o le aziende devono poter cercare negli allievi in base a ciò che hanno proseguito di fare
- **Contatti**: la scuola o le aziende devono poter contattare gli ex allievi per richiedere curriculum o colloqui, e viceversa

Requisiti di sistema

- **Sistema operativo**: Windows, in quanto usando linguaggi di programmazione specifici di Microsoft, come C# per il back-end e, Razor per il front-end si adatta perfettamente al contesto d'uso dell'applicazione, o Linux e MacOS.
- **Front-end**: Razor che è un motore di template che consente l'inserimento di codice C# direttamente nelle pagine HTML. Questo facilita il binding dinamico dei dati nel front-end, consentendo una gestione più efficiente della logica di presentazione.
- **Back-end**: ASP.NET Core 8.0 che è la versione più recente del framework di sviluppo web di Microsoft. Utilizzando C# come linguaggio principale, si possono sfruttare le funzionalità avanzate del linguaggio, come la strong typing e la gestione avanzata delle eccezioni, inoltre la struttura MVC consente di organizzare il codice in modo modulare, separando il modello dei dati, la logica di presentazione e il controllo del flusso dell'applicazione. Questo facilita la manutenibilità e la scalabilità del software, nonchè il binding dinamico delle pagine
- **Database**: SQLServer, database relazionale che si adatta molto bene all' uso di MVC con ASP.NET, essendo integrato nell' ambiente di sviluppo. Potrebbe essere utilizzato un ORM come Entity Framework, semplificando le operazioni di accesso e manipolazione dei dati nel database attraverso oggetti C#.
- **Interfaccia utente**: HTML5 con le sue nuove funzionalità, CSS, con Razor connesso al codice C# per l'uso di pagine dinamiche

Problemi nello sviluppo

Durante lo sviluppo del software ci possono essere diverse problematiche, come:

- **Sicurezza**: La configurazione del firewall e la sicurezza del database richiedono un'attenzione particolare. Un problema nella configurazione potrebbe esporre l'applicazione a rischi di sicurezza. Garantire che tutte le impostazioni di sicurezza siano corrette e aggiornate potrebbe richiedere una cura dettagliata.
- **Ottimizzazione query**: Nel caso di un database SQLServer, è comune incontrare problemi di prestazioni legati a query SQL non ottimizzate. Potrebbe essere necessario esaminare ed ottimizzare le query per garantire che l'applicazione mantenga alte prestazioni anche con un crescente volume di dati.
- **Incompatibilità versioni**: Potrebbe verificarsi un problema di incompatibilità tra diverse versioni di librerie o framework utilizzate nell'applicazione. Questo potrebbe richiedere tempo per risolvere i conflitti e garantire che tutte le componenti funzionino correttamente insieme.
- **Gestione sessioni**: La gestione delle sessioni utente in un'applicazione web può essere complessa. Problemi come la gestione delle sessioni scadute, la sicurezza delle informazioni sensibili memorizzate nei cookie o la corretta gestione dello stato delle sessioni potrebbero richiedere attenzione durante lo sviluppo.
- **Uso librerie esterne**: La gestione delle sessioni utente in un'applicazione web può essere complessa. Problemi come la gestione delle sessioni scadute, la sicurezza delle informazioni sensibili memorizzate nei cookie o la corretta gestione dello stato delle sessioni potrebbero richiedere attenzione durante lo sviluppo.

Installazione

Per rendere utilizzabile il nostro applicativo eseguire i seguenti passaggi, seguiti da un tecnico

- **Configurazione database**: Scaricare il sistema di gestione del database remoto, eseguire l'installazione seguendo le istruzioni fornite. Impostare le connessioni nel database, specificando le credenziali di accesso e le autorizzazioni necessarie per garantire una connessione sicura dall'applicativo, infine verificare la connettività tra l'applicativo e il database remoto per assicurarsi che le configurazioni siano corrette.
- **Configurazione C#**: Distribuzione del pacchetto dell'applicativo che include l'eseguibile C# e le risorse necessarie sui PC destinatari. Può essere distribuito tramite una condivisione di rete o un altro mezzo di distribuzione. Al primo avvio dell'applicativo su ogni PC destinatario, guidare gli utenti attraverso la configurazione iniziale. Questa fase potrebbe includere la scelta delle impostazioni locali, la configurazione dell'interfaccia utente e l'impostazione di preferenze utente, infine verificare che tutte le funzionalità dell'applicativo siano accessibili e operative correttamente sui PC destinatari.
- **Configurazione firewall**: Analizzare se nella rete aziendale è già presente un sistema di sicurezza. Se assente o non adeguato, considerare l'installazione di un firewall per proteggere l'ambiente da minacce esterne e gestire le regole di traffico se necessario scaricare e installare il firewall prescelto. Configurare le regole del firewall per consentire il traffico necessario all'applicativo e bloccare l'accesso non autorizzato, infine eseguire test per verificare che le regole del firewall siano configurate correttamente e che non impediscano il corretto funzionamento dell'applicativo.

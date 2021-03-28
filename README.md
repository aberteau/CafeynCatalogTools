# CafeynCatalogTools
Ce programme permet d'exporter la liste des publications disponibles dans le [catalogue Cafeyn/Bouygues](https://www.cafeyn.co/fr/bouygues/catalog) dans un fichier XML.

## Contexte
Ce programme a été développé en réponse à une demande d'assistance postée sur le groupe Facebook ["Entraide Excel Et VBA"](https://www.facebook.com/groups/593471877693774)
### Besoins
Pouvoir disposer de la liste des publications disponibles dans le [Catalogue Cafey pour Bouygues](https://www.cafeyn.co/fr/bouygues/catalog) dans un fichier Excel.

[Voir la demande d'assistance](https://www.facebook.com/groups/593471877693774/permalink/1373694826338138)

### Manipulations testées

#### Copier/Coller Navigateur > Excel
 _NOK_ : Toutes les publications sont dans la même cellule.

 En analysant le code HTML de la page, nous pouvons constater que les publications sont représentées par des balises `<a>`, il ne s'agit pas d'un "vrai" tableau HTML mais d'une mise en forme. Excel n'est donc pas capable d'identifier les cellules du tableau lors du copier/coller.

#### Utilisation URL comme source de données
 _NOK_ : Lors de l'utilisation comme source de données, aucune donnée récupérée.

 Après analyse du code HTML de la page et des échanges réseaux, nous pouvons constater qu'il s'agit d'appels asynchrones et que le contenu est chargé dynamiquement par le navigateur. Par conséquent, Excel n'étant pas capable de prendre en charge ce type d'interaction, il n'est pas possible de se servir de l'URL comme source de données.

### Solution proposée
Après analyse des appels effectués à l'API, il paraît tout à fait envisageable de développer un programme capable de :
1. interroger l'API utilisée par le navigateur pour récupérer la liste des publications au format JSON
2. transformer ces données pour les mettre au format XML qu'Excel saura interpréter sans difficultés.

### Informations techniques

#### Réponse API
[Extrait réponse API](sample-data/cafeyn-bouygues-publications.json)

#### Format XML
Le fichier XML représente un tableau de `PublicationDataRow`.
Cette structure contient les propriétés suivantes :

| Propriétés  |  Correspondance avec réponse API|
|---|---|
|StoreId  |  result.stores[i].storeId |
|StoreName  |  result.stores[i].name |
|CategoryId  | result.stores[i].categories[j].id  |
|CategoryName  |  result.stores[i].categories[j].name |
|PublicationId  | result.stores[i].categories[j].items[k].publicationId  |
|PublicationName  | result.stores[i].categories[j].items[k].title   |

[Extrait XML](sample-data/cafeyn-bouygues-publications.xml)

## Getting Started
### Prerequisites

Visual Studio 2019

## Authors

Amael BERTEAU

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

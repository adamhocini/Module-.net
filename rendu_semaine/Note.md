Prérequis

Installé .NET Core 8.0:

dotnet --version // la  version la plus recente installée

dotnet --list-sdks // liste des SDK installés

La premiere difference entre .NET et .NET Core est que .NET Core est open-source et cross-platform, tandis que .NET Framework est proprietaire et ne fonctionne que sur Windows.

La portabilite de .NET Core est possible car il ne depend pas de Windows, mais de CoreCLR, une version de CLR (Common Language Runtime) qui est cross-platform.

Les librairies NuGet : .NET Core utilise les librairies NuGet, qui sont des librairies open-source, tandis que .NET Framework utilise les librairies proprietaires de Microsoft. Cependant toutes les librairies .NET Framework ne sont pas encore portees sur .NET Core.

## Le pattern MVC

.NET utilise le pattern MVC (Model-View-Controller) pour developper des applications web:

Separation des couches logiques, metier et presentation
Razor Pages permet de creer des pages Web
du Model Binding et de la validation de Model

Voici l'architecture d'un projet .NET console (cf projet), pour en creer une il suffit de taper la commande suivante :

dotnet new console
On remarque que le contenu du code source est alors constituee d'une seule ligne dans le fichier Program.cs :

Console.WriteLine("Hello World!");
Si on veut obtenir un programme avec l'ancienne syntaxe, il suffit de taper la commande suivante :

dotnet new console --use-program-main

 dotnet new console --use-program-main -o consoleProject
Pour lancer le programme, il suffit de taper la commande suivante :

dotnet run

Pour creer un projet MVC, il suffit de taper la commande suivante :

dotnet new mvc

Creation d'une API WEB avec .NET 8.0

Dans votre terminal, tapez la commande suivante :

dotnet new webapi -o BookStoreApiNoControllers // cree une mini api web sans controllers

dotnet new webapi --use-controllers  --use-program-main -o BookStoreAPI // cree une  api web avec controllers


### Entity Framework Core / Entity Framework 8

Entity Framework Core est un ORM (Object Relational Mapper) qui permet de manipuler des donnees relationnelles en utilisant des objets .NET.

Avec EF, nous allons à partir des entités (classes) définies dans notre code, générer la base de données correspondante. Nous allons également pouvoir effectuer des opérations CRUD (Create, Read, Update, Delete) sur ces entités.

Les DTO (Data Transfer Object) et AutoMapper

Les DTO sont des objets qui permettent de transporter des donnees entre les couches de l'application. On ne veut pas que les objets de la couche metier soient exposes a la couche presentation, car cela peut poser des problemes de securite. Pour pallier à ce probleme, on utilise les DTO qui sont des objets qui contiennent les memes proprietes que les objets de la couche metier, mais qui sont exposes à la couche presentation. On utilise ensuite un outil qui permet de mapper les proprietes des objets de la couche metier vers les proprietes des objets DTO. Cet outil s'appelle AutoMapper.

## Authorization et Authentication avec asp .net core Identity

Pour mettre en place l'authentification et l'autorisation dans une application ASP .NET Core, il faut utiliser le package NuGet Microsoft.AspNetCore.Identity.EntityFrameworkCore, par exemple :

dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
.NET 8 vous fournit tous les outils necessaires pour mettre en place l'authentification et l'autorisation dans une application ASP .NET Core.

Methode
Http = controleur d'API

Rendu Pratique :

Développez une API REST avec .NET 8.0 qui permet de gérer une bibliothèque de livres ou une boutique en ligne de livres.

Decrivez votre API avec OpenAPI (Swagger) et un readme.md. Decrivez les fonctionnalités de votre API avec des schemas. (UML par exemple) et un readme.md. (Diagramme de classe, diagramme de séquence, diagramme d'activité, diagramme de cas d'utilisation, etc.)

Vous mettrez en place l'authentification et l'autorisation avec asp .net core Identity.

Vous mettrez en place la validation de données avec ModelState.

Vous utiliserez les DTO et AutoMapper.

Vous utiliserez Entity Framework Core pour accéder à une base de données SQLite.

Vous utiliserez les migrations pour créer la base de données.

Vous utiliserez les controllers pour gérer les requêtes HTTP.
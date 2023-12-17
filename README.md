# Projet : Intégration d'un module d'authentification et de gestion des utilisateurs
## Ce projet vise à intégrer un module d'authentification et de gestion des utilisateurs dans l'application School . 
## L'objectif principal est de permettre l'accès à différentes fonctionnalités selon le rôle de l'utilisateur.

### Aperçu
Page d'accueil de l'application
Types d'utilisateurs : Admin, Manager, User
Étapes
Installation de l'API Identity :

Installer les packages nécessaires (Microsoft.AspNetCore.Identity, Microsoft.AspNetCore.Identity.EntityFrameworkCore).
Configuration de l'Identity dans le code :

Utiliser IdentityDbContext dans StudentContext.
Configurer les services Identity dans Program.cs.
Ajout de l'authentification dans le pipeline de requêtes :

Utilisation des middlewares pour l'authentification et l'autorisation.
Migration et génération des tables Identity :

Utilisation d'Entity Framework Core pour créer les tables.
Création d'une vue pour l'enregistrement des utilisateurs :

Ajout du modèle RegisterViewModel.
Création de la vue correspondante dans Register.cshtml.
Contrôleur pour la gestion des comptes :

Ajout d'un AccountController avec les actions pour l'enregistrement et la gestion des utilisateurs.
...

#### Gestion des rôles
Configuration des options de mot de passe par défaut.
Affichage conditionnel des liens (Login, Logout, Register) en fonction de l'état de connexion de l'utilisateur.
Création de rôles (Admin, User) et attribution des autorisations.
...

### Administration des rôles
Création d'un AdminController pour gérer les rôles.
Ajout, suppression, édition des rôles.
Attribution des rôles à différents utilisateurs.
...

#### Autorisations spécifiques par rôle
Contrôle d'accès aux différentes parties de l'application en fonction du rôle.
Exemple : l'accès à SchoolController pour les rôles Admin et Manager.
...

### Gestion des accès refusés
Page spécifique en cas d'accès refusé à une ressource non autorisée.

# Output 


https://github.com/RyhabElmoncer/SChoolAPPAuthentification/assets/126770762/540c554a-ea72-4d84-90cf-e6f51e87937f


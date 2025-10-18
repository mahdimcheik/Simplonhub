# RoleApp Management - Documentation

## 📋 Vue d'ensemble

Cette documentation décrit l'implémentation de la gestion des **RoleApp** (Rôles d'application) avec les opérations CRUD (Create, Read, Update) - **sans Delete** comme demandé.

## 🗂️ Fichiers Créés

### **1. Models & DTOs** - `MainBoilerPlate/Models/RoleAppDTO.cs`
- **RoleAppResponseDTO** - DTO pour l'affichage détaillé
- **RoleAppCreateDTO** - DTO pour la création
- **RoleAppUpdateDTO** - DTO pour la mise à jour

### **2. Service** - `MainBoilerPlate/Services/RoleAppService.cs`
- `GetAllRolesAsync()` - Récupère tous les rôles
- `GetRoleByIdAsync(id)` - Récupère un rôle par ID
- `GetRoleByNameAsync(name)` - Récupère un rôle par nom
- `CreateRoleAsync(dto)` - Crée un nouveau rôle
- `UpdateRoleAsync(id, dto)` - Met à jour un rôle
- `GetUsersCountInRoleAsync(roleId)` - Compte les utilisateurs dans un rôle

### **3. Controller** - `MainBoilerPlate/Controllers/RoleAppController.cs`
- `GET /roleapp/all` - Liste tous les rôles
- `GET /roleapp/{id}` - Récupère un rôle par ID
- `GET /roleapp/by-name/{name}` - Récupère un rôle par nom
- `POST /roleapp/create` - Crée un nouveau rôle
- `PUT /roleapp/update/{id}` - Met à jour un rôle
- `GET /roleapp/{id}/users-count` - Compte les utilisateurs dans un rôle

### **4. Configuration** - `MainBoilerPlate/Program.cs`
- Enregistrement de `RoleAppService` dans le conteneur DI

---

## 📊 Structure des DTOs

### **RoleAppResponseDTO** (Affichage)
```csharp
{
  "id": "guid",
  "name": "string",
  "normalizedName": "string",
  "createdAt": "datetime",
  "updatedAt": "datetime"
}
```

### **RoleAppCreateDTO** (Création)
```csharp
{
  "name": "string"  // Required, max 64 caractères
}
```

### **RoleAppUpdateDTO** (Mise à jour)
```csharp
{
  "name": "string"  // Required, max 64 caractères
}
```

---

## 🚀 Endpoints de l'API

### **1. Récupérer tous les rôles**
```http
GET /roleapp/all
```

**Réponse 200 OK:**
```json
{
  "message": "Rôles récupérés avec succès",
  "status": 200,
  "data": [
    {
      "id": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5",
      "name": "SuperAdmin",
      "normalizedName": "SUPERADMIN",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    },
    {
      "id": "4a5eaf2f-0496-4035-a4b7-9210da39501c",
      "name": "Admin",
      "normalizedName": "ADMIN",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    },
    {
      "id": "87a0a5ed-c7bb-4394-a163-7ed7560b3703",
      "name": "Teacher",
      "normalizedName": "TEACHER",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    },
    {
      "id": "87a0a5ed-c7bb-4394-a163-7ed7560b4a01",
      "name": "Student",
      "normalizedName": "STUDENT",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    }
  ],
  "count": 4
}
```

---

### **2. Récupérer un rôle par ID**
```http
GET /roleapp/{id}
```

**Paramètres:**
- `id` (GUID) - Identifiant du rôle

**Réponse 200 OK:**
```json
{
  "message": "Rôle récupéré avec succès",
  "status": 200,
  "data": {
    "id": "4a5eaf2f-0496-4035-a4b7-9210da39501c",
    "name": "Admin",
    "normalizedName": "ADMIN",
    "createdAt": "2024-01-15T10:00:00Z",
    "updatedAt": null
  }
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Rôle non trouvé",
  "status": 404,
  "data": null
}
```

---

### **3. Récupérer un rôle par nom**
```http
GET /roleapp/by-name/{name}
```

**Paramètres:**
- `name` (string) - Nom du rôle (ex: "Admin", "Teacher")

**Exemple:**
```
GET /roleapp/by-name/Admin
```

**Réponse 200 OK:**
```json
{
  "message": "Rôle récupéré avec succès",
  "status": 200,
  "data": {
    "id": "4a5eaf2f-0496-4035-a4b7-9210da39501c",
    "name": "Admin",
    "normalizedName": "ADMIN",
    "createdAt": "2024-01-15T10:00:00Z",
    "updatedAt": null
  }
}
```

---

### **4. Créer un nouveau rôle**
```http
POST /roleapp/create
```

**Body:**
```json
{
  "name": "Manager"
}
```

**Réponse 201 Created:**
```json
{
  "message": "Rôle créé avec succès",
  "status": 201,
  "data": {
    "id": "new-guid-here",
    "name": "Manager",
    "normalizedName": "MANAGER",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": null
  }
}
```

**Réponse 400 Bad Request (nom existe déjà):**
```json
{
  "message": "Un rôle avec ce nom existe déjà",
  "status": 400,
  "data": null
}
```

---

### **5. Mettre à jour un rôle**
```http
PUT /roleapp/update/{id}
```

**Paramètres:**
- `id` (GUID) - Identifiant du rôle à modifier

**Body:**
```json
{
  "name": "Senior Manager"
}
```

**Réponse 200 OK:**
```json
{
  "message": "Rôle mis à jour avec succès",
  "status": 200,
  "data": {
    "id": "guid-here",
    "name": "Senior Manager",
    "normalizedName": "SENIOR MANAGER",
    "createdAt": "2024-01-15T10:00:00Z",
    "updatedAt": "2024-01-15T11:00:00Z"
  }
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Rôle non trouvé",
  "status": 404,
  "data": null
}
```

**Réponse 400 Bad Request (nom déjà utilisé):**
```json
{
  "message": "Un autre rôle avec ce nom existe déjà",
  "status": 400,
  "data": null
}
```

---

### **6. Compter les utilisateurs dans un rôle**
```http
GET /roleapp/{id}/users-count
```

**Paramètres:**
- `id` (GUID) - Identifiant du rôle

**Réponse 200 OK:**
```json
{
  "message": "Nombre d'utilisateurs récupéré avec succès",
  "status": 200,
  "data": 15
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Rôle non trouvé",
  "status": 404,
  "data": 0
}
```

---

## ✨ Fonctionnalités Implémentées

### **1. Validation des Données**
- ✅ Nom requis (max 64 caractères)
- ✅ Normalisation automatique du nom (UPPERCASE)
- ✅ Validation automatique avec ModelState

### **2. Règles Métier**
- ✅ **Unicité du nom** - Un nom de rôle ne peut pas être dupliqué
- ✅ **Normalisation** - Le nom est automatiquement converti en majuscules pour NormalizedName
- ✅ **Archivage** - Les rôles archivés sont exclus des résultats
- ✅ **Timestamps** - CreatedAt et UpdatedAt gérés automatiquement
- ✅ **Comptage** - Possibilité de compter les utilisateurs dans un rôle

### **3. Intégration avec ASP.NET Core Identity**
- ✅ Utilise **RoleManager<RoleApp>** pour la gestion des rôles
- ✅ Compatible avec le système d'authentification existant
- ✅ Gestion des erreurs Identity
- ✅ Vérification de l'existence avec FindByNameAsync

### **4. Pas de Delete**
- ⚠️ **Aucune opération de suppression** - Comme demandé
- 💡 Les rôles peuvent être archivés manuellement si nécessaire (ArchivedAt)

---

## 📝 Exemples d'Utilisation

### **Exemple 1: Créer un rôle "Manager"**
```bash
curl -X POST "https://api.example.com/roleapp/create" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Manager"
  }'
```

### **Exemple 2: Récupérer tous les rôles**
```bash
curl -X GET "https://api.example.com/roleapp/all"
```

### **Exemple 3: Récupérer un rôle par nom**
```bash
curl -X GET "https://api.example.com/roleapp/by-name/Admin"
```

### **Exemple 4: Mettre à jour un rôle**
```bash
curl -X PUT "https://api.example.com/roleapp/update/{id}" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Senior Manager"
  }'
```

### **Exemple 5: Compter les utilisateurs dans un rôle**
```bash
curl -X GET "https://api.example.com/roleapp/{id}/users-count"
```

---

## 🔐 Considérations de Sécurité

### **Recommandations:**
1. **Autorisation** - Ajouter `[Authorize]` sur les endpoints sensibles:
   ```csharp
   [Authorize(Roles = "SuperAdmin")]
   [HttpPost("create")]
   ```

2. **Restrictions** - Limiter la création/modification aux SuperAdmin uniquement
3. **Audit Trail** - Logger toutes les modifications de rôles
4. **Rôles Système** - Protéger les rôles système (SuperAdmin, Admin, Teacher, Student) contre la modification

---

## 🔗 Intégration avec UserApp

### **Assigner un rôle à un utilisateur:**
```csharp
// Dans AuthService ou UsersService
var user = await userManager.FindByIdAsync(userId.ToString());
var result = await userManager.AddToRoleAsync(user, "Manager");
```

### **Vérifier si un utilisateur a un rôle:**
```csharp
var isInRole = await userManager.IsInRoleAsync(user, "Admin");
```

### **Récupérer les rôles d'un utilisateur:**
```csharp
var userRoles = await userManager.GetRolesAsync(user);
```

### **Récupérer les utilisateurs dans un rôle:**
```csharp
var usersInRole = await userManager.GetUsersInRoleAsync("Teacher");
```

---

## 🎯 Rôles Prédéfinis dans le Système

| Rôle | GUID (HardCode) | Description |
|------|-----------------|-------------|
| **SuperAdmin** | `bde5556b-562d-431f-9ff9-d31a5f5cb8c5` | Accès complet au système |
| **Admin** | `4a5eaf2f-0496-4035-a4b7-9210da39501c` | Administration générale |
| **Teacher** | `87a0a5ed-c7bb-4394-a163-7ed7560b3703` | Enseignants |
| **Student** | `87a0a5ed-c7bb-4394-a163-7ed7560b4a01` | Étudiants |

---

## 🧪 Tests

### **Scénarios de Test Recommandés:**

#### **Tests Positifs:**
1. ✅ Créer un nouveau rôle avec un nom valide
2. ✅ Récupérer la liste de tous les rôles
3. ✅ Récupérer un rôle par son ID
4. ✅ Récupérer un rôle par son nom
5. ✅ Mettre à jour un rôle existant
6. ✅ Compter les utilisateurs dans un rôle

#### **Tests Négatifs:**
1. ❌ Créer un rôle avec un nom existant
2. ❌ Créer un rôle avec un nom vide
3. ❌ Mettre à jour avec un nom déjà utilisé
4. ❌ Récupérer un rôle avec un ID inexistant
5. ❌ Récupérer un rôle avec un nom inexistant

---

## 📊 Codes de Statut HTTP

| Code | Signification | Utilisation |
|------|---------------|-------------|
| 200 | OK | Opération réussie (GET, PUT) |
| 201 | Created | Création réussie (POST) |
| 400 | Bad Request | Données invalides ou règle métier violée |
| 404 | Not Found | Ressource non trouvée |
| 500 | Internal Server Error | Erreur serveur inattendue |

---

## 🎨 Utilisation avec Authorization

### **Protéger un endpoint par rôle:**
```csharp
[Authorize(Roles = "Admin,SuperAdmin")]
[HttpGet("admin-only")]
public async Task<ActionResult> AdminOnlyEndpoint()
{
    // Code accessible uniquement aux Admin et SuperAdmin
}
```

### **Vérifier plusieurs rôles:**
```csharp
[Authorize(Roles = "Admin,Teacher,SuperAdmin")]
[HttpGet("teachers-and-admins")]
public async Task<ActionResult> TeachersAndAdminsEndpoint()
{
    // Code accessible aux enseignants et administrateurs
}
```

---

## ⚠️ Limitations

### **1. Pas de suppression**
- Les rôles ne peuvent pas être supprimés via l'API
- Pour "supprimer" un rôle, utiliser l'archivage manuel (ArchivedAt)

### **2. Rôles système**
- Les rôles prédéfinis (SuperAdmin, Admin, Teacher, Student) devraient être protégés
- Recommandation: Ajouter une validation pour empêcher leur modification

---

## ✅ Résumé

### **Ce qui a été implémenté:**
- ✅ CRUD complet **SANS DELETE** pour RoleApp
- ✅ DTOs pour Create, Update et Response
- ✅ Service avec logique métier et RoleManager
- ✅ Controller avec documentation Swagger
- ✅ Validation des données
- ✅ Gestion des erreurs Identity
- ✅ Comptage des utilisateurs par rôle
- ✅ Recherche par ID et par nom

### **Points clés:**
- Tous les endpoints sont documentés pour Swagger
- Utilisation de RoleManager pour la compatibilité Identity
- Les noms sont vérifiés pour l'unicité
- Normalisation automatique des noms
- Gestion appropriée des codes HTTP
- **Aucune opération de suppression** (comme demandé)

### **Endpoints disponibles:**
- `GET /roleapp/all` - Liste tous les rôles
- `GET /roleapp/{id}` - Rôle par ID
- `GET /roleapp/by-name/{name}` - Rôle par nom
- `POST /roleapp/create` - Créer un rôle
- `PUT /roleapp/update/{id}` - Modifier un rôle
- `GET /roleapp/{id}/users-count` - Compter les utilisateurs
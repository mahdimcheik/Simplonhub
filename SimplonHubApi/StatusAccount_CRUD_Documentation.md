# StatusAccount CRUD - Documentation

## 📋 Vue d'ensemble

Cette documentation décrit l'implémentation complète du CRUD (Create, Read, Update, Delete) pour l'entité **StatusAccount** (Statut de compte).

## 🗂️ Fichiers Créés/Modifiés

### **1. Models & DTOs** - `MainBoilerPlate/Models/StatusAccount.cs`
- **StatusAccountResponseDTO** - DTO pour l'affichage détaillé
- **StatusAccountCreateDTO** - DTO pour la création
- **StatusAccountUpdateDTO** - DTO pour la mise à jour
- **StatusAccountDTO** - DTO existant conservé pour compatibilité

### **2. Service** - `MainBoilerPlate/Services/StatusAccountService.cs`
- `GetAllStatusAccountsAsync()` - Récupère tous les statuts
- `GetStatusAccountByIdAsync()` - Récupère un statut par ID
- `CreateStatusAccountAsync()` - Crée un nouveau statut
- `UpdateStatusAccountAsync()` - Met à jour un statut
- `DeleteStatusAccountAsync()` - Suppression logique d'un statut

### **3. Controller** - `MainBoilerPlate/Controllers/StatusAccountController.cs`
- `GET /statusaccount/all` - Liste tous les statuts
- `GET /statusaccount/{id}` - Récupère un statut par ID
- `POST /statusaccount/create` - Crée un nouveau statut
- `PUT /statusaccount/update/{id}` - Met à jour un statut
- `DELETE /statusaccount/delete/{id}` - Supprime un statut

### **4. Configuration** - `MainBoilerPlate/Program.cs`
- Enregistrement de `StatusAccountService` dans le conteneur DI

---

## 📊 Structure des DTOs

### **StatusAccountResponseDTO** (Affichage)
```csharp
{
  "id": "guid",
  "name": "string",
  "color": "string",    // Format: #RRGGBB
  "icon": "string",     // Optionnel
  "createdAt": "datetime",
  "updatedAt": "datetime"  // Optionnel
}
```

### **StatusAccountCreateDTO** (Création)
```csharp
{
  "name": "string",        // Required, max 64 caractères
  "color": "string",       // Required, format hexadécimal #RRGGBB
  "icon": "string"         // Optionnel, max 256 caractères
}
```

### **StatusAccountUpdateDTO** (Mise à jour)
```csharp
{
  "name": "string",        // Required, max 64 caractères
  "color": "string",       // Required, format hexadécimal #RRGGBB
  "icon": "string"         // Optionnel, max 256 caractères
}
```

---

## 🚀 Endpoints de l'API

### **1. Récupérer tous les statuts**
```http
GET /statusaccount/all
```

**Réponse 200 OK:**
```json
{
  "message": "Statuts de compte récupérés avec succès",
  "status": 200,
  "data": [
    {
      "id": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5",
      "name": "Pending",
      "color": "#ff69b4",
      "icon": "fa-clock",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    },
    {
      "id": "4a5eaf2f-0496-4035-a4b7-9210da39501c",
      "name": "Confirmed",
      "color": "#28a745",
      "icon": "fa-check-circle",
      "createdAt": "2024-01-15T10:00:00Z",
      "updatedAt": null
    }
  ],
  "count": 2
}
```

---

### **2. Récupérer un statut par ID**
```http
GET /statusaccount/{id}
```

**Paramètres:**
- `id` (GUID) - Identifiant du statut

**Réponse 200 OK:**
```json
{
  "message": "Statut de compte récupéré avec succès",
  "status": 200,
  "data": {
    "id": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5",
    "name": "Pending",
    "color": "#ff69b4",
    "icon": "fa-clock",
    "createdAt": "2024-01-15T10:00:00Z",
    "updatedAt": null
  }
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Statut de compte non trouvé",
  "status": 404,
  "data": null
}
```

---

### **3. Créer un nouveau statut**
```http
POST /statusaccount/create
```

**Body:**
```json
{
  "name": "Active",
  "color": "#28a745",
  "icon": "fa-check-circle"
}
```

**Réponse 201 Created:**
```json
{
  "message": "Statut de compte créé avec succès",
  "status": 201,
  "data": {
    "id": "new-guid-here",
    "name": "Active",
    "color": "#28a745",
    "icon": "fa-check-circle",
    "createdAt": "2024-01-15T10:30:00Z",
    "updatedAt": null
  }
}
```

**Réponse 400 Bad Request (nom existe déjà):**
```json
{
  "message": "Un statut de compte avec ce nom existe déjà",
  "status": 400,
  "data": null
}
```

---

### **4. Mettre à jour un statut**
```http
PUT /statusaccount/update/{id}
```

**Paramètres:**
- `id` (GUID) - Identifiant du statut à modifier

**Body:**
```json
{
  "name": "Active",
  "color": "#28a745",
  "icon": "fa-check"
}
```

**Réponse 200 OK:**
```json
{
  "message": "Statut de compte mis à jour avec succès",
  "status": 200,
  "data": {
    "id": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5",
    "name": "Active",
    "color": "#28a745",
    "icon": "fa-check",
    "createdAt": "2024-01-15T10:00:00Z",
    "updatedAt": "2024-01-15T11:00:00Z"
  }
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Statut de compte non trouvé",
  "status": 404,
  "data": null
}
```

**Réponse 400 Bad Request (nom déjà utilisé):**
```json
{
  "message": "Un autre statut de compte avec ce nom existe déjà",
  "status": 400,
  "data": null
}
```

---

### **5. Supprimer un statut**
```http
DELETE /statusaccount/delete/{id}
```

**Paramètres:**
- `id` (GUID) - Identifiant du statut à supprimer

**Réponse 200 OK:**
```json
{
  "message": "Statut de compte supprimé avec succès",
  "status": 200,
  "data": null
}
```

**Réponse 404 Not Found:**
```json
{
  "message": "Statut de compte non trouvé",
  "status": 404,
  "data": null
}
```

**Réponse 400 Bad Request (statut utilisé):**
```json
{
  "message": "Ce statut de compte est utilisé par des utilisateurs et ne peut pas être supprimé",
  "status": 400,
  "data": null
}
```

---

## ✨ Fonctionnalités Implémentées

### **1. Validation des Données**
- ✅ Nom requis (max 64 caractères)
- ✅ Couleur requise (format hexadécimal #RRGGBB ou #RGB)
- ✅ Icône optionnelle (max 256 caractères)
- ✅ Validation automatique avec ModelState

### **2. Règles Métier**
- ✅ **Unicité du nom** - Un nom ne peut pas être dupliqué
- ✅ **Vérification de l'utilisation** - Un statut utilisé par des utilisateurs ne peut pas être supprimé
- ✅ **Suppression logique** - Les statuts sont archivés (ArchivedAt) plutôt que supprimés
- ✅ **Timestamps** - CreatedAt et UpdatedAt gérés automatiquement

### **3. Sécurité & Qualité**
- ✅ **Try-Catch** - Gestion des erreurs sur toutes les opérations
- ✅ **AsNoTracking** - Optimisation des lectures
- ✅ **Case-insensitive** - Comparaison des noms insensible à la casse
- ✅ **Codes HTTP** - Utilisation appropriée des codes de statut HTTP

---

## 📝 Exemples d'Utilisation

### **Exemple 1: Créer un statut "Active"**
```bash
curl -X POST "https://api.example.com/statusaccount/create" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Active",
    "color": "#28a745",
    "icon": "fa-check-circle"
  }'
```

### **Exemple 2: Récupérer tous les statuts**
```bash
curl -X GET "https://api.example.com/statusaccount/all"
```

### **Exemple 3: Mettre à jour un statut**
```bash
curl -X PUT "https://api.example.com/statusaccount/update/{id}" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Verified",
    "color": "#17a2b8",
    "icon": "fa-shield-alt"
  }'
```

### **Exemple 4: Supprimer un statut**
```bash
curl -X DELETE "https://api.example.com/statusaccount/delete/{id}"
```

---

## 🔐 Considérations de Sécurité

### **À Implémenter (selon besoins):**
1. **Autorisation** - Ajouter `[Authorize]` sur les endpoints sensibles
2. **Rôles** - Restreindre certaines opérations aux admins:
   ```csharp
   [Authorize(Roles = "Admin,SuperAdmin")]
   ```
3. **Rate Limiting** - Limiter le nombre de requêtes
4. **Audit Trail** - Logger les modifications

---

## 🧪 Tests

### **Scénarios de Test Recommandés:**

#### **Tests Positifs:**
1. ✅ Créer un nouveau statut avec toutes les données valides
2. ✅ Récupérer la liste de tous les statuts
3. ✅ Récupérer un statut par son ID
4. ✅ Mettre à jour un statut existant
5. ✅ Supprimer un statut non utilisé

#### **Tests Négatifs:**
1. ❌ Créer un statut avec un nom existant
2. ❌ Créer un statut avec une couleur invalide
3. ❌ Mettre à jour avec un nom déjà utilisé
4. ❌ Supprimer un statut utilisé par des utilisateurs
5. ❌ Récupérer un statut avec un ID inexistant

---

## 📊 Codes de Statut HTTP

| Code | Signification | Utilisation |
|------|---------------|-------------|
| 200 | OK | Opération réussie (GET, PUT, DELETE) |
| 201 | Created | Création réussie (POST) |
| 400 | Bad Request | Données invalides ou règle métier violée |
| 404 | Not Found | Ressource non trouvée |
| 500 | Internal Server Error | Erreur serveur inattendue |

---

## 🎨 Exemples de Couleurs de Statut

| Statut | Couleur | Hex Code | Icon |
|--------|---------|----------|------|
| Pending | Orange | `#ffc107` | `fa-clock` |
| Confirmed | Vert | `#28a745` | `fa-check-circle` |
| Banned | Rouge | `#dc3545` | `fa-ban` |
| Suspended | Gris | `#6c757d` | `fa-pause-circle` |
| Active | Bleu | `#007bff` | `fa-shield-alt` |

---

## 🔄 Intégration avec d'autres Entités

### **UserApp**
Les utilisateurs ont une propriété `StatusId` qui référence un StatusAccount:
```csharp
public class UserApp
{
    public Guid StatusId { get; set; }
    public StatusAccount? Status { get; set; }
}
```

### **Utilisation dans les requêtes:**
```csharp
var users = await context.Users
    .Include(u => u.Status)
    .Where(u => u.Status.Name == "Confirmed")
    .ToListAsync();
```

---

## ✅ Résumé

### **Ce qui a été implémenté:**
- ✅ CRUD complet pour StatusAccount
- ✅ DTOs pour Create, Update et Response
- ✅ Service avec logique métier
- ✅ Controller avec documentation Swagger
- ✅ Validation des données
- ✅ Gestion des erreurs
- ✅ Suppression logique
- ✅ Vérification de l'intégrité référentielle

### **Points clés:**
- Tous les endpoints sont documentés pour Swagger
- La validation hexadécimale de la couleur est en place
- Les noms sont vérifiés pour l'unicité
- Les statuts utilisés ne peuvent pas être supprimés
- Gestion appropriée des codes HTTP
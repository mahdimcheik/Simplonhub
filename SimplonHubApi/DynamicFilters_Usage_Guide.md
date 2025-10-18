# Guide d'utilisation - Filtres Dynamiques avec TableState

## 📋 Vue d'ensemble

Le système de filtres dynamiques permet d'appliquer des filtres, des tris et de la pagination sur n'importe quelle entité de manière dynamique via l'API.

## 🔍 Match Modes Disponibles

### 1. **equals** - Égalité stricte
Vérifie si une propriété est égale à une valeur donnée.

**Exemple:**
```json
{
  "filters": {
    "statusId": {
      "value": "550e8400-e29b-41d4-a716-446655440000",
      "matchMode": "equals"
    }
  }
}
```
**SQL équivalent:** `WHERE StatusId = '550e8400-e29b-41d4-a716-446655440000'`

---

### 2. **notequals** - Différent de
Vérifie si une propriété est différente d'une valeur donnée.

**Exemple:**
```json
{
  "filters": {
    "statusId": {
      "value": "550e8400-e29b-41d4-a716-446655440000",
      "matchMode": "notequals"
    }
  }
}
```
**SQL équivalent:** `WHERE StatusId != '550e8400-e29b-41d4-a716-446655440000'`

---

### 3. **contains** - Contient (strings uniquement)
Vérifie si une chaîne de caractères contient une sous-chaîne.

**Exemple:**
```json
{
  "filters": {
    "firstName": {
      "value": "John",
      "matchMode": "contains"
    }
  }
}
```
**SQL équivalent:** `WHERE FirstName LIKE '%John%'`

---

### 4. **startswith** - Commence par (strings uniquement)
Vérifie si une chaîne commence par une sous-chaîne.

**Exemple:**
```json
{
  "filters": {
    "email": {
      "value": "admin",
      "matchMode": "startswith"
    }
  }
}
```
**SQL équivalent:** `WHERE Email LIKE 'admin%'`

---

### 5. **endswith** - Termine par (strings uniquement)
Vérifie si une chaîne se termine par une sous-chaîne.

**Exemple:**
```json
{
  "filters": {
    "email": {
      "value": "@fake.com",
      "matchMode": "endswith"
    }
  }
}
```
**SQL équivalent:** `WHERE Email LIKE '%@fake.com'`

---

### 6. **gt** - Plus grand que
Vérifie si une valeur est supérieure à une autre.

**Exemple:**
```json
{
  "filters": {
    "age": {
      "value": "18",
      "matchMode": "gt"
    }
  }
}
```
**SQL équivalent:** `WHERE Age > 18`

---

### 7. **gte** - Plus grand ou égal
Vérifie si une valeur est supérieure ou égale à une autre.

**Exemple:**
```json
{
  "filters": {
    "createdAt": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    }
  }
}
```
**SQL équivalent:** `WHERE CreatedAt >= '2024-01-01T00:00:00Z'`

---

### 8. **lt** - Plus petit que
Vérifie si une valeur est inférieure à une autre.

**Exemple:**
```json
{
  "filters": {
    "price": {
      "value": "100",
      "matchMode": "lt"
    }
  }
}
```
**SQL équivalent:** `WHERE Price < 100`

---

### 9. **lte** - Plus petit ou égal
Vérifie si une valeur est inférieure ou égale à une autre.

**Exemple:**
```json
{
  "filters": {
    "stock": {
      "value": "50",
      "matchMode": "lte"
    }
  }
}
```
**SQL équivalent:** `WHERE Stock <= 50`

---

### 10. **any** - Dans une liste ✨ NOUVEAU
Vérifie si une propriété correspond à l'une des valeurs d'une liste.

**Format:** Les valeurs doivent être séparées par des virgules.

**Exemple avec GUIDs (StatusIds):**
```json
{
  "filters": {
    "statusId": {
      "value": "550e8400-e29b-41d4-a716-446655440000,4a5eaf2f-0496-4035-a4b7-9210da39501c,87a0a5ed-c7bb-4394-a163-7ed7560b3703",
      "matchMode": "any"
    }
  }
}
```
**SQL équivalent:** 
```sql
WHERE StatusId IN (
  '550e8400-e29b-41d4-a716-446655440000',
  '4a5eaf2f-0496-4035-a4b7-9210da39501c',
  '87a0a5ed-c7bb-4394-a163-7ed7560b3703'
)
```

**Exemple avec nombres entiers:**
```json
{
  "filters": {
    "categoryId": {
      "value": "1,2,3,5,8",
      "matchMode": "any"
    }
  }
}
```
**SQL équivalent:** `WHERE CategoryId IN (1, 2, 3, 5, 8)`

**Exemple avec strings:**
```json
{
  "filters": {
    "role": {
      "value": "Admin,Teacher,SuperAdmin",
      "matchMode": "any"
    }
  }
}
```
**SQL équivalent:** `WHERE Role IN ('Admin', 'Teacher', 'SuperAdmin')`

---

## 📊 Utilisation Complète

### Structure de base
```json
{
  "first": 0,
  "rows": 10,
  "globalSearch": "",
  "sorts": [
    {
      "field": "createdAt",
      "order": -1
    }
  ],
  "filters": {
    "propertyName": {
      "value": "filterValue",
      "matchMode": "matchMode"
    }
  }
}
```

### Exemple complet avec plusieurs filtres
```json
{
  "first": 0,
  "rows": 20,
  "sorts": [
    {
      "field": "createdAt",
      "order": -1
    },
    {
      "field": "lastName",
      "order": 1
    }
  ],
  "filters": {
    "statusId": {
      "value": "4a5eaf2f-0496-4035-a4b7-9210da39501c,87a0a5ed-c7bb-4394-a163-7ed7560b3703",
      "matchMode": "any"
    },
    "firstName": {
      "value": "John",
      "matchMode": "contains"
    },
    "email": {
      "value": "@fake.com",
      "matchMode": "endswith"
    },
    "createdAt": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    }
  }
}
```

**Cet exemple va:**
- Filtrer les utilisateurs avec des statusIds spécifiques (using "any")
- Dont le prénom contient "John"
- Dont l'email se termine par "@fake.com"
- Créés après le 1er janvier 2024
- Trier par date de création (descendant) puis par nom (ascendant)
- Retourner les 20 premiers résultats

---

## 🎯 Cas d'usage spécifiques pour "any"

### 1. Filtrer par plusieurs statuts
```json
{
  "filters": {
    "statusId": {
      "value": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5,4a5eaf2f-0496-4035-a4b7-9210da39501c",
      "matchMode": "any"
    }
  }
}
```
**Utilisation:** Récupérer les utilisateurs avec le statut "Pending" OU "Confirmed"

### 2. Filtrer par plusieurs genres
```json
{
  "filters": {
    "genderId": {
      "value": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5,4a5eaf2f-0496-4035-a4b7-9210da39501c",
      "matchMode": "any"
    }
  }
}
```
**Utilisation:** Récupérer les utilisateurs "Male" OU "Female"

### 3. Filtrer par plusieurs types de créneaux
```json
{
  "filters": {
    "typeId": {
      "value": "guid1,guid2,guid3",
      "matchMode": "any"
    }
  }
}
```
**Utilisation:** Récupérer les créneaux de plusieurs types

### 4. Filtrer par IDs d'utilisateurs spécifiques
```json
{
  "filters": {
    "teacherId": {
      "value": "user-guid-1,user-guid-2,user-guid-3",
      "matchMode": "any"
    }
  }
}
```
**Utilisation:** Récupérer les créneaux de plusieurs enseignants

---

## 📝 Notes importantes

### Format des valeurs pour "any"
- **Séparateur:** Virgule (`,`)
- **Espaces:** Les espaces avant/après les valeurs sont automatiquement supprimés
- **Valeurs vides:** Ignorées automatiquement
- **Type:** Les valeurs sont automatiquement converties au type de la propriété

### Exemples de formats acceptés
```json
// ✅ Correct
"value": "guid1,guid2,guid3"

// ✅ Correct (avec espaces)
"value": "guid1, guid2, guid3"

// ✅ Correct (avec espaces multiples)
"value": "guid1,  guid2  ,  guid3"

// ❌ Incorrect (point-virgule)
"value": "guid1;guid2;guid3"

// ❌ Incorrect (tableau JSON)
"value": ["guid1", "guid2", "guid3"]
```

### Types supportés
Le match mode "any" fonctionne avec tous les types de propriétés :
- ✅ `Guid`
- ✅ `int`, `long`, `short`
- ✅ `string`
- ✅ `decimal`, `double`, `float`
- ✅ `DateTime`, `DateTimeOffset`
- ✅ `bool`
- ✅ Tous types primitifs et structures

---

## 🚀 Exemples d'utilisation dans les contrôleurs

### Exemple avec le contrôleur Users
```http
POST /users/filter
Content-Type: application/json

{
  "first": 0,
  "rows": 50,
  "sorts": [
    {
      "field": "lastName",
      "order": 1
    }
  ],
  "filters": {
    "statusId": {
      "value": "4a5eaf2f-0496-4035-a4b7-9210da39501c,87a0a5ed-c7bb-4394-a163-7ed7560b3703",
      "matchMode": "any"
    },
    "genderId": {
      "value": "bde5556b-562d-431f-9ff9-d31a5f5cb8c5",
      "matchMode": "equals"
    },
    "firstName": {
      "value": "John",
      "matchMode": "contains"
    }
  }
}
```

### Exemple avec le contrôleur Slots
```http
POST /slots/filter
Content-Type: application/json

{
  "first": 0,
  "rows": 100,
  "sorts": [
    {
      "field": "dateFrom",
      "order": 1
    }
  ],
  "filters": {
    "typeId": {
      "value": "type-guid-1,type-guid-2",
      "matchMode": "any"
    },
    "teacherId": {
      "value": "teacher-guid-1,teacher-guid-2,teacher-guid-3",
      "matchMode": "any"
    },
    "dateFrom": {
      "value": "2024-01-01T00:00:00Z",
      "matchMode": "gte"
    }
  }
}
```

---

## ⚡ Performance

### Optimisations
- Les filtres sont compilés en expressions LINQ
- Traduits directement en SQL par Entity Framework
- Pas de chargement en mémoire des données avant filtrage
- Index de base de données utilisés automatiquement

### Bonnes pratiques
1. **Limiter le nombre de résultats:** Utilisez `rows` pour la pagination
2. **Indexer les colonnes filtrées:** Créez des index sur les propriétés fréquemment filtrées
3. **Combiner les filtres:** Plusieurs filtres sont combinés avec AND (plus performant)
4. **Utiliser "any" intelligemment:** Évitez des listes trop longues (> 50 valeurs)

---

## 🔧 Exemples de code C#

### Utilisation dans un service
```csharp
public async Task<ResponseDTO<List<UserResponseDTO>>> FilterUsers(
    DynamicFilters<UserApp> filters)
{
    var query = context.Users
        .Where(u => u.ArchivedAt == null)
        .ApplyDynamicWhere(filters)
        .ApplySorts(filters);
    
    var users = await query.ToListAsync();
    
    return new ResponseDTO<List<UserResponseDTO>>
    {
        Status = 200,
        Data = users.Select(u => new UserResponseDTO(u)).ToList()
    };
}
```

### Utilisation dans un contrôleur
```csharp
[HttpPost("filter")]
public async Task<ActionResult<ResponseDTO<List<SlotResponseDTO>>>> FilterSlots(
    [FromBody] DynamicFilters<Slot> filters)
{
    var query = context.Slots
        .Where(s => s.ArchivedAt == null)
        .Include(s => s.Teacher)
        .Include(s => s.Type)
        .ApplyDynamicWhere(filters)
        .ApplySorts(filters);
    
    var slots = await query.ToListAsync();
    
    return Ok(new ResponseDTO<List<SlotResponseDTO>>
    {
        Status = 200,
        Data = slots.Select(s => new SlotResponseDTO(s)).ToList()
    });
}
```
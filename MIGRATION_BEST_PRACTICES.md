# Database Migration Best Practices

## 1. Why is removing a column more dangerous than adding one?

Removing a column is destructive and irreversible:
- Data Loss: The column and all its data are permanently deleted. There's no way to recover it without backups.
- Application Breakage: If code still references the removed column, it will crash at runtime.

Adding a column is safer because it's non-destructive

---

## 2. Why are migrations preferred over manual SQL changes?

Migrations treat schema as code, enabling safe, repeatable database changes.

---

## 3. What could go wrong if two developers modify the schema without migrations?

**Merge Conflicts & Chaos**:
- Both developers manually run SQL on their local/staging databases
- One dev removes a column, the other adds it → database state is undefined
- No way to know which changes should be applied first
- The codebase doesn't reflect what's actually in the database

**Data Consistency**:
- Different environments have different schemas 
- Tests pass locally but fail in production
- Backup/restore procedures break when schema expectations don't align

---

## 4. Which schema changes in this project would be risky in production, and why?

### Risky Changes:

1. **Removing non-nullable columns** 
   - Existing bookings would have NULL rooms
   - Application code crashes when accessing `booking.Room.RoomNumber`
   - Data corruption occurs

2. **Changing column constraints** 
   - Existing rooms with capacity < 10 or > 20 still exist
   - Validation logic in ConferenceRoom constructor conflicts with DB state

3. **Renaming tables or columns**
   - Old application version still queries conRooms → query fails
   - Deployment must be coordinated: schema change + code update simultaneously


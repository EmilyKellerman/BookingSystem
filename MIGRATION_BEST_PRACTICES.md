# Database Migration Best Practices

## 1. Why is removing a column more dangerous than adding one?

Removing a column is **destructive** and irreversible:
- **Data Loss**: The column and all its data are permanently deleted. There's no way to recover it without backups.
- **Application Breakage**: If code still references the removed column, it will crash at runtime.
- **Concurrent Users**: Users connected to the database may have queries in flight that reference the column.
- **Rollback Difficulty**: Rolling back requires restoring from backups, which can lose recent data.

Adding a column is safer because:
- It's additive and non-destructive
- Old code continues to work (it just ignores the new column)
- It can be rolled back easily without data loss
- New code can opt-in to use it

**Best Practice**: Make removed columns nullable first, deprecate them in code, then remove after ensuring no dependencies exist.

---

## 2. Why are migrations preferred over manual SQL changes?

| Aspect | Migrations | Manual SQL |
|--------|-----------|-----------|
| **Version Control** | Tracked in code, reviewable | Ad-hoc scripts, hard to trace |
| **Reproducibility** | Consistent across environments (dev, staging, prod) | Risk of manual mistakes, drift between environments |
| **Rollback** | Built-in `Down()` methods restore previous schema | Must write reverse SQL manually, error-prone |
| **Documentation** | Each migration documents what changed and why | No automatic record of changes |
| **Order of Execution** | Guaranteed correct sequence | Human error prone, especially with dependencies |
| **Team Collaboration** | Clear merge/conflict resolution in code | Difficult to coordinate who applied what |
| **Automation** | Can be integrated into CI/CD pipelines | Requires manual intervention |

Migrations treat schema as code, enabling safe, auditable, repeatable database changes.

---

## 3. What could go wrong if two developers modify the schema without migrations?

**Merge Conflicts & Chaos**:
- Both developers manually run SQL on their local/staging databases
- One dev removes a column, the other adds it → database state is undefined
- No way to know which changes should be applied first
- The codebase doesn't reflect what's actually in the database

**Production Disasters**:
- One dev's changes don't exist on production because they were never documented
- Deployment skips unknown schema changes, causing runtime errors
- Rollback is impossible—manual SQL has no inverse

**Data Consistency**:
- Different environments have different schemas (dev ≠ staging ≠ prod)
- Tests pass locally but fail in production
- Backup/restore procedures break when schema expectations don't align

**No Audit Trail**:
- Nobody knows who changed what, when, or why
- Debugging production issues becomes a guessing game
- Compliance/audit requirements fail

---

## 4. Which schema changes in this project would be risky in production, and why?

### Risky Changes:

1. **Removing non-nullable columns** (e.g., removing `Booking.Room`)
   - Existing bookings would have NULL rooms
   - Application code crashes when accessing `booking.Room.RoomNumber`
   - Data corruption occurs

2. **Changing column constraints** (e.g., `Capacity` from 10-20 to 5-30)
   - Existing rooms with capacity < 10 or > 20 still exist
   - Validation logic in `ConferenceRoom` constructor conflicts with DB state
   - Silent data inconsistency

3. **Renaming tables or columns** (e.g., `conRooms` → `conferenceRooms`)
   - Old application version still queries `conRooms` → query fails
   - Deployment must be coordinated: schema change + code update simultaneously
   - Window of downtime if versions are deployed separately

4. **Adding NOT NULL columns without defaults**
   - Existing rows would have NULL values, violating the constraint
   - Migration fails or creates invalid data

### Safe Alternatives for Production:

- **Add nullable columns first**, then populate data, then add NOT NULL constraint
- **Create new tables** instead of renaming; migrate data gradually, then deprecate old table
- **Use feature flags** to roll out code changes independent of schema changes
- **Backward compatibility**: Keep old column alongside new one during transition period
- **Test migrations** in staging first, with production-like data volumes


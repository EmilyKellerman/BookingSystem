# Authorization Design Notes

## Why Authorization Should Not Live in Controllers

Controllers must remain thin. Mixing authorization logic with request handling creates:
- Testability issues: Authorization logic becomes coupled to HTTP concerns
- Code duplication: Role checks repeated across multiple endpoints
- Maintenance burden: Changing authorization rules requires controller updates

Instead middleware enforces rules before actions are invoked. 

This separates concerns: controllers handle business logic, middleware handles security gates.

## Why Roles Belong in Tokens

JWTs are **self-contained credentials**. Embedding roles in the token ensures:

1. No database lookup needed for every request — role claims are cryptographically signed and immediately available
2. Distributed system readiness — services don't need to contact a central auth database
3. Scalability — reduced authorization checks
4. Client awareness — frontend can decode the token to determine UI availability

## Preparing for Scaling: Data Relations, Ownership, and Frontend

### Database Relationships
Storing role assignments allows:
- Users to hold multiple roles dynamically
- Easy role assignment/revocation without token renewal
- Audit trails of authorization changes

### Booking Ownership
Future endpoints can validate ownership:

This combines role-based with attribute-based authorization.

### Frontend Integration
The client can:
- Decode the JWT to extract roles and user ID
- Conditionally render UI (hide "Create Room" for non-Facilities Managers)
- Pass the token in subsequent requests 
- Handle 403 Forbidden responses gracefully

---


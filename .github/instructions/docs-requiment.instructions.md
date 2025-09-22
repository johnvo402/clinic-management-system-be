---
applyTo: '**'
---
# Project Structure Description for Simplified Clinic Management System

## Overview
This document outlines the business analysis (BA), technical aspects, API design, and other components for a simplified clinic management application. The system focuses on core workflows: patient reception, medical examination, diagnosis, and prescribing medicine (primarily imported drugs). No support for lab tests, imaging, or other subclinical procedures. Pre-defined codes for items (e.g., drugs, diagnoses) are auto-populated via selections.

## 1. Business Analysis (BA)
### Project Overview
- **Objective**: Build an efficient mobile app for small clinics to manage patient visits, emphasizing quick prescriptions of imported drugs with pre-coded identifiers.
- **Scope**: In-scope: Patient intake, examination, diagnosis, prescription. Out-of-scope: Lab integration, advanced imaging, detailed financial analytics, inventory beyond basic drug tracking.
- **Assumptions**: Users are clinic staff; drugs pre-loaded with codes; app supports offline mode with sync.
- **Risks**: Patient data privacy; accurate drug code maintenance.


### Functional Requirements
- **Patient Reception (Tiếp Đón)**:
  - Register/search patients by name/ID.
  - Capture basics: Name, age, gender, contact, visit reason.
  - User Story: As a receptionist, I can queue patients for doctors.
- **Medical Examination (Khám Bệnh)**:
  - Record symptoms/history.
  - Select diagnosis from coded list.
  - User Story: As a doctor, I can document exams and auto-fill diagnosis codes.
- **Diagnosis (Chẩn Đoán)**:
  - Use pre-defined codes (e.g., ICD-like).
  - Allow notes but prioritize codes.
  - User Story: As a doctor, select diagnosis to populate code.
- **Prescription (Cho Thuốc)**:
  - Search/select imported drugs by code/name.
  - Add dosage, quantity, instructions.
  - Generate/shareable prescription.
  - User Story: As a doctor, add drugs with codes, focusing on imports.
- **Basic Financials (Quản Lý Thu Chi)**:
  - Calculate fees/drug costs.
  - Log payments.
  - User Story: As staff, record simple thu chi.

### Non-Functional Requirements
- **Performance**: Quick loads (<2s); handle 50 patients/day.
- **Usability**: Mobile-friendly UI; Vietnamese support.
- **Security**: Data encryption; role-based access.
- **Scalability**: Single-clinic focus; cloud sync option.

### Business Process Flow
- Flow: Patient arrives → Reception → Queue → Exam → Diagnosis → Prescription → Payment → End.
- Suggestion: Model with BPMN diagram.

## 3. API Design

- **Authentication**: JWT bearer token required.

### Endpoints
- **Patients**:
  CRUD, GetDetail
- **Visits**:
  CURD, List by Patients
- **Drugs**:
  CRUD
- **Prescriptions**:
  CRUD,   Get by Visits
- **Unit**:
  CRUD

### API Best Practices
- **Errors**: Standard JSON {error, code}.
- **Rate Limiting**: Built-in ASP.NET middleware.
- **Docs**: Swagger integrated.
- **Security**: HTTPS; input validation.

## 4. Additional Components
- **Testing Plan**: Unit (xUnit), integration (EF Core), UAT with staff.
- **Deployment & Maintenance**: Expo for app publishing; CI/CD with GitHub Actions; DB backups.
- **Cost Estimate**: Low with open-source; MVP in 4-6 weeks.
- **Future Enhancements**: Add analytics; integrate basic inventory.

This Markdown file serves as the project blueprint. Adjust as needed for implementation.
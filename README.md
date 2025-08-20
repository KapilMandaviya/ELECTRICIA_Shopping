ELECTRICIA‑Shopping

> Full‑stack e‑commerce web app for a single‑brand electronics store. Frontend: Angular. Backend: ASP.NET Core Web API. Database: SQL Server. Payments: Stripe (test & live ready).




---

🧭 Repository Overview

This monorepo contains the Angular storefront and the .NET API for ELECTRICIA‑Shopping, an electronics e‑commerce site inspired by Lenovo‑style product taxonomy (products, variants, accessories, bundles). It supports dynamic catalog management, carts, orders, discounts, and secure checkout.

root
├─ /client/                     # Angular app (v18+)
│  ├─ src/app/
│  │  ├─ core/                 # interceptors, guards, services
│  │  ├─ features/             # products, cart, checkout, account, admin
│  │  ├─ shared/               # ui components, pipes, directives, models
│  │  └─ pages/                # home, category, product detail, search
│  ├─ environments/            # env configs (dev/prod)
│  └─ ...
├─ /server/                     # ASP.NET Core 8 Web API
│  ├─ ELECTRICIA.Api/          # API project
│  ├─ ELECTRICIA.Application/  # use cases, DTOs, validators
│  ├─ ELECTRICIA.Domain/       # entities, aggregates, enums
│  ├─ ELECTRICIA.Infrastructure/# EF Core, repositories, migrations
│  └─ ELECTRICIA.Tests/        # unit/integration tests
└─ /docs/                       # architecture, ADRs, diagrams, SQL scripts

✨ Features

Add to Cart: add/remove/update quantities; persists for guests and signed‑in users.

Wishlist (Favorites): add/remove items; move items from wishlist → cart.

Product Catalog: categories → subcategories → products → variants; specs & attributes; images; new‑arrival & featured flags.

Search & Filters: keyword search, price range, brand, specs, availability.

Promotions: percentage/amount discounts, new‑arrival highlights, timed deals.

Checkout & Payments: address & shipping, order summary, Stripe Payment Element with Payment Intents (test & live ready).

Order Management: order creation, status flow (Pending → Paid → Shipped → Completed/Cancelled); invoices.

Accounts: register/login, JWT auth, roles (Admin/Customer), profile, addresses.

Admin: manage products, inventory, pricing, banners, orders, and users.

Observability: request logging, correlation IDs, basic health checks.


> Roadmap items are listed near the end of this README.




---

🧰 Tech Stack

Frontend: Angular 18, RxJS, Angular Router, Forms
; Stripe Payment Element.

Backend: ASP.NET Core 8 Web API (C# .NET 8), Entity Framework Core, FluentValidation, AutoMapper.

Database: Microsoft SQL Server 2019+.

Auth: JWT Bearer tokens; role‑based authorization.

CI/CD: GitHub Actions (build, test, deploy) with caching for npm and .NET; status badges optional.

Hosting: Any cloud; verified on Render for demo deployments.



---

🚀 Quick Start (Local)

Prerequisites

Node.js 20+, npm 10+

Angular CLI 18+

.NET SDK 8.0+

SQL Server (local or remote)

Stripe account (test mode keys)


1) Clone & Configure

# Clone
git clone https://github.com/Kapilmandaviya/ELECTRICIA-Shopping.git
cd ELECTRICIA-Shopping

# Copy sample env files
cp client/.env.example client/.env
cp server/ELECTRICIA.Api/appsettings.Development.json.example \
   server/ELECTRICIA.Api/appsettings.Development.json

Update the following values in your env files:

client/.env

NG_APP_API_BASE_URL=http://localhost:5001
NG_APP_STRIPE_PUBLISHABLE_KEY=pk_test_****************

server/ELECTRICIA.Api/appsettings.Development.json

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ELECTRICIA;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Issuer": "ELECTRICIA",
    "Audience": "ELECTRICIA",
    "Key": "super‑secret‑dev‑key‑change‑me"
  },
  "Stripe": {
    "SecretKey": "sk_test_****************",
    "WebhookSecret": "whsec_****************"
  },
  "Logging": { "LogLevel": { "Default": "Information" } }
}

2) Database

# from /server
cd server
# apply migrations
dotnet ef database update --project ELECTRICIA.Infrastructure --startup-project ELECTRICIA.Api

# optional: seed sample data
dotnet run --project ELECTRICIA.Api -- --seed

3) Run the API

cd server/ELECTRICIA.Api
dotnet run
# API listens on http://localhost:5001 (http) and https://localhost:7001 (https)

4) Run the Angular app

cd client
npm install
npm start # or: ng serve -o

Visit http://localhost:4200.


---

🔐 Environment Variables

Name	Where	Description

NG_APP_API_BASE_URL	client	Base URL of the API
NG_APP_STRIPE_PUBLISHABLE_KEY	client	Stripe publishable key
ConnectionStrings:DefaultConnection	server	SQL Server connection string
Jwt:Key/Issuer/Audience	server	JWT auth config
Stripe:SecretKey	server	Stripe secret key (server‑side)
Stripe:WebhookSecret	server	Webhook signing secret (server‑side)


> Never commit real secrets. Use Git ignored .env/user secrets/hosted secrets.




---

🏗️ Architecture

Domain‑Driven layering: Domain → Application → Infrastructure → API.

EF Core repositories with unit of work; migrations for schema evolution.

DTOs & Validation using AutoMapper + FluentValidation.

JWT Auth via Authorization: Bearer <token>; role policies for Admin endpoints.

Stripe: Payment Intent created server‑side; client uses Payment Element; order status updates on webhook payment_intent.succeeded.


High‑Level Flow

1. User browses catalog (Angular → /api/products etc.).


2. Adds items to cart; creates checkout session → API creates Payment Intent.


3. Stripe confirms payment; webhook notifies API; order captured & inventory updated.




---

📡 API Surface (excerpt)

GET    /api/health
POST   /api/auth/register
POST   /api/auth/login
GET    /api/products?search=&category=&minPrice=&maxPrice=&sort=
GET    /api/products/{id}
GET    /api/categories
POST   /api/cart        # create/update cart (guest or user)
POST   /api/checkout    # creates/updates Payment Intent, returns client secret
POST   /api/stripe/webhook  # receives events
GET    /api/orders/me   # requires auth
GET    /api/admin/orders               # Admin
POST   /api/admin/products             # Admin
PUT    /api/admin/products/{id}        # Admin

> See docs/api.http and Swagger UI at /swagger when API is running.




---

🧪 Testing

Backend: xUnit + FluentAssertions; integration tests with Testcontainers or local SQL.

Frontend: Karma/Jasmine or Jest; Cypress for e2e (optional).


# backend
dotnet test

# frontend
npm test


---

🧹 Code Quality

Frontend: ESLint, Prettier, Angular strict mode.

Backend: analyzers (Microsoft.CodeAnalysis), StyleCop (optional).

Conventional Commits + semantic versioning.


# format & lint
npm run lint && npm run format


---

🔄 CI/CD (GitHub Actions)

Build & test on push/PR for both client and server.

Publish Docker images or artifacts on tagged releases.

Example workflows in .github/workflows/:

ci-client.yml – Angular build

ci-server.yml – .NET build & tests



> Deploy targets: Render, Azure App Service, or any container host.




---

💳 Stripe Integration

This project has Stripe fully integrated end‑to‑end.

Server creates/updates PaymentIntents and returns the client_secret.

Angular uses the Payment Element to confirm the payment.

Webhook payment_intent.succeeded updates order status and inventory.

Works with test & live keys. For India, amounts should be sent in the smallest currency unit (paise) when using integer minor units.


Local webhook forwarding


Use test cards like 4242 4242 4242 4242 with any future expiry and any CVC.


---

🗃️ Database & Seed

Seed creates sample categories, products, accessories, and a default Admin user.

To regenerate migrations:


# from /server
dotnet ef migrations add Init --project ELECTRICIA.Infrastructure --startup-project ELECTRICIA.Api


---

🧩 Configuration Flags

Features:EnableNewArrival – toggles New Arrival ribbon & listing.

Features:EnableDiscounts – enables discount engine.

Features:EnableGuestCheckout – allow guest checkout.



---

🛠️ Troubleshooting

CORS errors: confirm AllowedOrigins includes http://localhost:4200.

Payment not visible in Stripe: ensure you’re in test mode and using test keys; verify Payment Intent creation returns a valid client_secret.

SQL errors: check connection string and run migrations; SQL Server must allow TCP/IP.

Angular amount binding: verify [amount] input receives a number in the smallest currency unit (e.g., paise) if required by your component.


---

🙌 Contributing

1. Fork the repo and create a feature branch.


2. Commit using Conventional Commits.


3. Open a PR with a clear description and screenshots for UI changes.




---

🗺️ Roadmap

Wishlists & product comparisons

Inventory reservations during checkout

Reviews & Q&A

Admin dashboards & analytics

Multi‑warehouse shipping rules

Internationalization & multi‑currency



---

📣 Repo Description (for GitHub)

> ELECTRICIA‑Shopping – Single‑brand electronics e‑commerce built with Angular 18 + ASP.NET Core 8 + SQL Server. Includes product catalog, add to cart, wishlist, discounts, JWT auth, and Stripe checkout with webhooks. CI/CD via GitHub Actions; ready for local dev and cloud deploys (tested on Render).




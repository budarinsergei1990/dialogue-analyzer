\# Dialogue Analyzer



AI-powered dialogue analysis service that builds psychological profiles and provides personalized communication insights.



\## What it does

\- Accepts dialogue text via Telegram bot or Web API

\- Builds psychological profiles of participants

\- Analyzes communication patterns (intents, conflict arcs, behavioral traits)

\- Provides personalized recommendations

\- Tracks profile evolution over time



\## Tech Stack

\- \*\*Backend:\*\* C#, .NET 8, ASP.NET Core Web API

\- \*\*Architecture:\*\* Clean Architecture, CQRS, Pipeline Pattern

\- \*\*AI:\*\* Semantic Kernel + DeepSeek (Phase 3)

\- \*\*Database:\*\* PostgreSQL + pgvector (for RAG)

\- \*\*Infrastructure:\*\* Docker, GitHub Actions (CI/CD)

\- \*\*Client:\*\* Telegram Bot (Long Polling / Webhook)



\## Project Status

\- \[x] Phase 1: Core architecture, health-check, Docker, tests

\- \[ ] Phase 2: Domain entities, mock pipeline, working Telegram bot

\- \[ ] Phase 3: AI integration (DeepSeek + Semantic Kernel)

\- \[ ] Phase 4: Production infrastructure (PostgreSQL, Redis)

\- \[ ] Phase 5: Production-ready deployment


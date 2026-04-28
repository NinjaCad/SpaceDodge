# Space Dodge (Unity WebGL Game)

This repository contains a **Unity WebGL build** of a game (served as a static website).

## Play / run
### Option 1: Open the GitHub Pages site
If GitHub Pages is enabled for this repo, you can play it directly in your browser.

### Option 2: Run locally (recommended for testing)
Because this is a WebGL build, it should be served from a local web server (opening `index.html` directly may fail due to browser restrictions).

#### Using Python
```bash
python -m http.server 8000
```
Then open: http://localhost:8000

#### Using Node (any static server)
```bash
npx serve
```

## Repository structure
- **`index.html`** — Main page that loads the Unity WebGL build.
- **`Build/`** — Unity WebGL build outputs (multiple build variants appear to be present):
  - `Dodge for GitHub.*` (e.g., `.data`, `.framework.js`, `.loader.js`, `.wasm`)
  - `Dodge v1.*.gz` and `Dodge v2.*.gz` (compressed build artifacts)
- **`TemplateData/`** — Unity WebGL template assets (CSS/images for the loader UI).
- **`images/`** — Site images (currently includes `favicon.png`).
- **`Game.zip`** — A zipped game/build artifact.

## Overview
This repo is a static site wrapper around one (or more) Unity WebGL exports. The HTML page sets up a canvas, loads the Unity loader script, and points it at the build artifacts in `Build/`.

# AR Product Preview App

**Augmented Reality - Product Preview with Hand Gesture Control**

This project enables users to preview e-commerce products in their physical environment using Augmented Reality (AR) on Android devices. It uses Unity3D with ARFoundation and integrates with cloud-based storage (FTP/Google Drive) to fetch and render 3D models of products. Users can interact with the product using hand gestures such as pinch (resize), swipe (rotate), and double tap (reposition).

---

## 🧠 Features

- Marker-less AR with plane detection
- Product list fetched from cloud storage
- Downloads and renders 3D model of selected product
- Hand gesture interactions for scaling, rotating, and repositioning
- Real-time environment mapping using SLAM
- Light and motion tracking to provide smooth experience

---

## 🛠️ Tech Stack

- **Game Engine**: Unity3D
- **Languages**: C#
- **Frameworks/APIs**: AR Foundation, ARCore
- **Backend Storage**: FTP Server / Google Drive (for Asset Bundles)

---

## 📁 Code Modules

- `LoadModels.cs`: Downloads and loads 3D product models dynamically from cloud
- `PlaceObjectsOnPlane.cs`: Detects surface and places product model on double tap
- `DisableTrackedVisuals.cs`: Disables visual clutter after placement
- `UIManager.cs`: Manages UI flow based on AR session state
- `ARUXAnimationManager.cs`: Animates instructions (Scan/Tap to Place)
- `ARUXReasonsManager.cs`: Displays reasons for tracking loss

---

## 🧩 Architecture

1. User opens the AR app.
2. Selects a product from the list.
3. The app downloads the respective 3D model.
4. Using AR SLAM + plane detection, a surface is identified.
5. On double tap, the product appears in the selected space.
6. User interacts with product via hand gestures.

---

## 📸 Screenshots

![Product List](./screenshots/product-list.png)
![Download Progress](./screenshots/download-screen.png)
![AR Preview](./screenshots/ar-preview.png)

---

## 🏷️ Keywords

Unity, C#, Augmented Reality, AR Foundation, Gesture Control, E-Commerce, 3D Models, SLAM, Plane Detection

---

## 📌 Note

This app is developed for enhancing the online shopping experience using mobile AR technology.

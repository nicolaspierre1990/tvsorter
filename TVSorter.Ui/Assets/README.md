# TVSorter Assets

This folder contains the application's visual assets (icons, logos, images).

## Required Files

Please add the following files to this directory:

### 1. Application Icon
- **File:** `tvsorter.ico`
- **Format:** Windows Icon (.ico)
- **Sizes:** Multiple sizes (16x16, 32x32, 48x48, 256x256)
- **Usage:** Application icon shown in taskbar, window title bar, and file explorer
- **Design:** Should be the colorful TVSorter logo with blue accent (#0078D4)

### 2. Grayscale Logo (for Splash Screen)
- **File:** `logo-grayscale.png`
- **Format:** PNG with transparency
- **Recommended Size:** 800x160 pixels (or similar aspect ratio)
- **Usage:** Displayed on the splash screen during application startup
- **Design:** Grayscale version of the TVSorter logo (no colors, just grays)
- **Background:** Transparent

### 3. Color Logo (optional, for future use)
- **File:** `logo-color.png`
- **Format:** PNG with transparency
- **Recommended Size:** 800x160 pixels
- **Usage:** Could be used in About dialog, documentation, etc.
- **Design:** Full color TVSorter logo with blue accent (#0078D4)

## Design Guidelines

### Color Palette
- **Primary Blue:** `#0078D4` (Microsoft Blue)
- **Background:** `#F0F0F0` (Light Gray)
- **Text Dark:** `#333333` (Dark Gray)
- **Text Medium:** `#666666` (Medium Gray)
- **Text Light:** `#999999` (Light Gray)

### Icon Design Tips
1. Keep it simple and recognizable at small sizes
2. Use the TV/monitor concept combined with organization symbols
3. Ensure it looks good against both light and dark backgrounds
4. Test at multiple sizes (16x16, 32x32, 48x48, 256x256)

### Logo Design Tips
1. The grayscale version should maintain readability without color
2. Use transparency for the background
3. Ensure text is legible at various sizes
4. Consider using a wider aspect ratio (5:1 or 4:1) for horizontal layouts

## Asset Generation

If you used an AI image generator (like DALL-E, Midjourney, etc.), you can:
1. Generate the color logo first
2. Convert it to grayscale for the splash screen version
3. Use online tools to convert PNG to ICO format with multiple sizes

## File Structure

```
TVSorter.Ui/
??? Assets/
    ??? tvsorter.ico          (required)
    ??? logo-grayscale.png    (required)
    ??? logo-color.png        (optional)
    ??? README.md             (this file)
```

## Integration

The assets are already configured in the application:
- ? Project file updated to include Assets folder
- ? Application icon set in project properties
- ? Splash screen updated to display grayscale logo
- ? Main window configured to use icon
- ? Avalonia resource system configured

Once you add the image files, the application will automatically use them!

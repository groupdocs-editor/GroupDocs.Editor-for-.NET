/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
    "node_modules/@groupdocs/groupdocs.editor.angular.ui-core/**/**/*.mjs",
    "node_modules/@groupdocs/groupdocs.editor.angular.ui-presentation/**/**/*.mjs",
  ],
  darkMode: 'class',
  theme: {
    extend: {},
  },
  plugins: [],
}

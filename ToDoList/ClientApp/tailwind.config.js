/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        'primary': '#FB2C00',
        'secondary': '#D97706',
        'custom-green': '#2ecc71',
        'custom-red': '#e74c3c',
        'custom-blue': {
          'light': '#3498db',
          'DEFAULT': '#2980b9',
          'dark': '#1f618d',
        },
        'bg-primary': '#D2ECEA'
      },
    },
  },
  plugins: [],
}
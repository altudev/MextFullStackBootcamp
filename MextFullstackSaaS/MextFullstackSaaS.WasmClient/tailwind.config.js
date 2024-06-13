/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor,html,cshtml}'],
    theme: {
        extend: {
            fontFamily: {
                poppins: ['Poppins', 'sans-serif'],
                // You can add other font families if needed
            },
        },
    },
  plugins: [
      require('daisyui'),
    ],
  daisyui: {
      themes: [
          "dark",
          "black",
          "night",
          "sunset"
      ],
  },
}


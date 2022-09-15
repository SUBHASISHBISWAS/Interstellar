const PROXY_CONFIG = [
  {
    context: ["/weatherforecast"],
    target: "https://localhost:4200",
    secure: false,
  },
];

module.exports = PROXY_CONFIG;

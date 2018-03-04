const PROXY_CONFIG = [
  {
    context: [
      "/api",
      "/assets"
    ],
    target: "http://localhost:58972",
    secure: false
  }
]

module.exports = PROXY_CONFIG;

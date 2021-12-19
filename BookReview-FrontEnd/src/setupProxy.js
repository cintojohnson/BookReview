﻿const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/BookReview",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7000',
        secure: false
    });

    app.use(appProxy);
};

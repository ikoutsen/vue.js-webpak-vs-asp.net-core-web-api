var path = require('path')
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    mode: 'development',
    entry: './clientapp/src/main.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        publicPath: 'wwwroot/dist/',
        filename: 'build.js'
    },
    module: {
        rules: [
            { test: /\.js$/, use: 'babel-loader' },
            { test: /\.vue$/, use: 'vue-loader' },
            { test: /\.css$/, use: ['vue-style-loader', 'css-loader'] },
        ]
    },
    plugins: [
        new VueLoaderPlugin(),
    ]
}
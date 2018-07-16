const path = require('path'),
    webpack = require('webpack'),
    HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: {
        app: ['./src/index.tsx', 'webpack-hot-middleware/client'],
        vendor: ['react', 'react-dom']
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'dist'),
    },
    devtool: 'source-map',
    resolve: {
        extensions: ['.js', '.json', '.ts', '.tsx'],
    },
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/,
                loader: 'ts-loader',
            },
            { enforce: "pre", test: /\.js$/, loader: "source-map-loader" }
        ],
    },
    plugins: [
        new HtmlWebpackPlugin({ template: path.resolve(__dirname, 'src', 'index.html') }),
        new webpack.HotModuleReplacementPlugin()
    ]
};
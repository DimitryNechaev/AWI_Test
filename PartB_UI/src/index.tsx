import * as React from 'react';
import { render } from 'react-dom';
import App from './App';

// hot reloading
declare let module: any

render(
    <App message="World3" />,
    document.getElementById('root'),
);

// hot reloading
if (module.hot) {
    module.hot.accept();
 }
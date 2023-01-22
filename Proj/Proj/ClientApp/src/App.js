//import React, { Component, Fragment } from 'react';
//import { Route, Routes } from 'react-router-dom';
//import AppRoutes from './AppRoutes';
//import { Layout } from './components/Layout';
import './custom.css';
import Layout from './components/shared/Layout';

function App() {
  return (
    <Layout>
      <h1>Привет Димон</h1>
    </Layout>
  );
}
export default App;

//export default class App extends Component {
 // static displayName = App.name;
//  render() {
//    return (
 //     <Layout>
//        
 //      <Routes>
//          {AppRoutes.map((route, index) => {
 //           const { element, ...rest } = route;
 //           return <Route key={index} {...rest} element={element} />;
 //           
//          })}         
//        </Routes>
//        </Layout>
//    );
//  }
//}

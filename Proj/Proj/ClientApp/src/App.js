import React, { Component, Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import Layout from './components/shared/Layout';


export default class App extends Component {
  static displayName = App.name;

  

  render() {
    return (
      <Layout>
        <h1>Привет Димон</h1>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
            
          })}
          
        </Routes>
      </Layout>
    );
  }
}
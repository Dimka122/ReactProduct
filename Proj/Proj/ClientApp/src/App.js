//import React, { Component, Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';
//import AppRoutes from './AppRoutes';
//import { Layout } from './components/Layout';
import './custom.css';
import Layout from './components/shared/Layout';
import AllSuperVillain from './pages/AllSuperVillain';
import AddSuperVillain from './pages/AddSuperVillain';
import UpdateSuperVillain from './pages/UpdateSuperVillain';



function App() {
  return (
    <Layout>
      <h1>Привет Димон</h1>
      <Routes>
        <Route path="/" element={<AllSuperVillain />} />
      </Routes>
      <Routes>
        <Route path="/supervillain-create" element={<AddSuperVillain />} />
      </Routes>
      <Routes>
      <Route path="/supervillain-update/:id" element={<UpdateSuperVillain />} />
      </Routes>
    </Layout>
  );
}
export default App;


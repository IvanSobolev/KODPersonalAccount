import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './components/Navbar';
import Profile from './components/Profile';
import Groups from './components/Groups';

const App = () => {
  return (
      <Router>
        <div style={{ maxWidth: '480px', margin: 'auto' }}>
          <Routes>
            <Route path="/profile" element={<Profile />} />
            <Route path="/groups" element={<Groups />} />
          </Routes>
          <Navbar />
        </div>
      </Router>
  );
};

export default App;
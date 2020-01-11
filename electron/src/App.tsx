import * as React from 'react';
import { MemoryRouter as Router, Link, Route, Switch } from 'react-router-dom';
import './App.scss';

export default () => (
  <Router>
    <div className="app">
      <nav className="activity-bar">
        <div className="composite">
          <Link to="/">build</Link>
          <Link to="/history">history</Link>
        </div>
        <div className="global">
          <Link to="/settings">settings</Link>
        </div>
      </nav>
      <Switch>
        <Route path="/" exact>
          <p>build</p>
        </Route>
        <Route path="/history">
          <p>history</p>
        </Route>
        <Route path="/settings">
          <p>settings</p>
        </Route>
        <Route>404</Route>
      </Switch>
    </div>
  </Router>
);

import React from 'react';
import {
  MemoryRouter as Router,
  NavLink,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom';
import Build from './pages/Build';
import History from './pages/History';
import Settings from './pages/Settings';
import styled from 'styled-components';

const App = styled.div`
  display: flex;
  flex-direction: row;
`;

const ActivityBar = styled.nav`
  height: 100vh;
  overflow: hidden;
  display: flex;
  flex-direction: column;
  background: var(--color-primary);
`;

const ActivityGroup = styled.div`
  display: flex;
  flex-direction: column;

  &.composite {
    flex: 1;
  }

  &.global {
  }
`;

const StyledNavLink = styled(NavLink)`
  --size: 3rem;

  width: var(--size);
  height: var(--size);
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: calc(var(--size) / 2);
  position: relative;

  color: var(--color-text--disabled);

  &.active,
  &:hover {
    color: var(--color-text);
  }

  /* active indicator */
  &::before {
    content: '';
    position: absolute;
    left: 0;
    width: 0.1em;
    height: 100%;
  }
  &.active::before {
    background: var(--color-text);
  }
`;

export default () => (
  <Router>
    <App>
      <ActivityBar>
        {Object.entries({
          composite: [Build, History],
          global: [Settings],
        }).map((kv, i) => {
          const [group, pages] = kv;
          return (
            <ActivityGroup key={i} className={group}>
              {pages.map((page, j) => (
                <StyledNavLink
                  key={j}
                  activeClassName="active"
                  to={page.path}
                  title={page.title}
                >
                  <page.icon />
                </StyledNavLink>
              ))}
            </ActivityGroup>
          );
        })}
      </ActivityBar>
      <Switch>
        {/* 로드 후 PPT 만들기로 자동 전환 */}
        <Route path="/" exact>
          <Redirect to={Build.path} />
        </Route>
        <Route path={Build.path}>{Build.component}</Route>
        <Route path={History.path}>{History.component}</Route>
        <Route path={Settings.path}>{Settings.component}</Route>
        <Route>404</Route>
      </Switch>
    </App>
  </Router>
);

import { useContext, useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import
  {
    Button,
    Collapse,
    Nav,
    NavLink,
    NavItem,
    Navbar,
    NavbarBrand,
    NavbarToggler,
  } from "reactstrap";
import { logout } from "../managers/authManager";
import { UserContext } from "../App";

export default function NavBar({ loggedInUser, setLoggedInUser })
{
  const [open, setOpen] = useState(false);
  const user = useContext(UserContext)

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar color="light" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          ✍️ Tabloid
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                {loggedInUser.roles.includes("Admin") && (
                  <>
                    <NavItem>
                      <NavLink tag={RRNavLink} to="/userprofiles">
                        User Profiles
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={RRNavLink} to="/post/unapproved">
                        Pending Approval
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={RRNavLink} to="/tags">
                        Tags
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={RRNavLink} to="/categories">
                        Categories
                      </NavLink>
                    </NavItem>
                    <NavItem>
                      <NavLink tag={RRNavLink} to="/create-reactions">
                        Reactions
                      </NavLink>
                    </NavItem>
                    
                  </>
                )}
                <NavItem>
                  <NavLink tag={RRNavLink} to="/post">
                    Posts
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/post/create">
                    Create Post
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={RRNavLink} to={`/userprofiles/${user.id}`}>
                    Profile
                  </NavLink>
                </NavItem>
              </Nav>
            </Collapse>
            <Button
              color="primary"
              onClick={(e) =>
              {
                e.preventDefault();
                setOpen(false);
                logout().then(() =>
                {
                  setLoggedInUser(null);
                  setOpen(false);
                });
              }}
            >
              Logout
            </Button>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}

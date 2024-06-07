import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserProfileList from "./userprofiles/UserProfilesList";
import UserProfileDetails from "./userprofiles/UserProfileDetails";
import PostByAuthor from "./AuthorsPost/PostByAuthor.jsx";
import PostList from "./PostList";
import { CategoriesView } from "./categories/CategoriesView";
import CreatePost from "./CreatePost";
import { CategoriesCreate } from "./categories/categoriesCreate/CategoriesCreate";
import PostDetails from "./PostDetails";
import { TagsView } from "./tags/TagsView";
import EditPost from "./EditPost";
import UserIsAuthor from "./UserIsAuthor";
import { CategoriesEdit } from "./categories/categoriesEdit/CategoriesEdit";
import { ReactionsCreateView } from "./reactions/ReactionsCreateView";
import { TagsEditView } from "./tags/tagsEdit/TagsEditView";
import { TagsCreate } from "./tags/tagsCreate/TagCreate";
import { CommentForm } from "./CommentForm";
import UserIsProfile from "./userprofiles/UserIsProfile";
import { EditCommentForm } from "./EditCommentForm";
import UnapprovedPosts from "./UnapprovedPosts";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <p>Welcome to Tabloid!</p>
            </AuthorizedRoute>
          }
        />
        <Route
          path=":CommentId/comment-edit"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <EditCommentForm />
            </AuthorizedRoute>
          }
        />
        <Route
          path="create-reactions"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
              <ReactionsCreateView />
            </AuthorizedRoute>
          }
        />
        <Route path="/userprofiles">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <UserProfileList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <UserProfileDetails />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="/categories">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <CategoriesView />
              </AuthorizedRoute>
            }
          />
          <Route path=":CategoryId/edit" element={<CategoriesEdit />} />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <CategoriesCreate />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="/tags">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <TagsView />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <TagsCreate />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":TagId/edit"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <TagsEditView />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route path="post">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <PostList />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreatePost />
              </AuthorizedRoute>
            }
          />
          <Route path=":postId">
            <Route
              index
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <PostDetails loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
            <Route
              path="edit"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <UserIsAuthor>
                    <EditPost />
                  </UserIsAuthor>
                </AuthorizedRoute>
              }
            />
            <Route
              path="comment"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <CommentForm loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
          </Route>
          <Route
            path="unapproved"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <UnapprovedPosts />
              </AuthorizedRoute>
            }
          />
        </Route>
      </Route>
      <Route
          path="myPosts"
          element={<PostByAuthor loggedInUser={loggedInUser} />}
        />
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}

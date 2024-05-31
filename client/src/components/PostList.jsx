import { Fragment, useContext, useEffect, useState } from "react";
import { getPublicPosts } from "../managers/postManager";
import { Link } from "react-router-dom";
import { UserContext } from "../App";
import "./PostView.css";
import { getAllCategories } from "../managers/categories";

const PostList = () => {
  const user = useContext(UserContext);
  const [selectedCategory, setSelectedCategory] = useState(0);
  const [posts, setPosts] = useState([]);
  const [filteredPosts, setFilteredPosts] = useState([]);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    getAllCategories().then(setCategories);
  }, []);

  useEffect(() => {
    getPublicPosts().then((posts) => {
      setPosts(
        posts.sort((a, b) => new Date(b.publication) - new Date(a.publication))
      );
    });
  }, []);

  useEffect(() => {
    if (selectedCategory === 0) {
      setFilteredPosts(posts);
    } else {
      setFilteredPosts(posts.filter((p) => p.categoryId == selectedCategory));
    }
  }, [selectedCategory, posts]);

  return (
    <main>
      <div className="PostList-div-maincontainer">
        <select
          defaultValue={0}
          onChange={(e) => {
            setSelectedCategory(parseInt(e.target.value));
          }}
        >
          <option value={0}>--All Categories--</option>
          {categories.map((c) => {
            return (
              <option key={c.id} value={c.id}>
                {c.categoryName}
              </option>
            );
          })}
        </select>
        <section className="PostList-section-posts">
          {filteredPosts.map((p) => (
            <article key={"p" + p.id} className="PostList-post-border">
              <header className="PostList-post-header">
                {p.publication}{" "}
                {p.authorId == user.id && (
                  <Link to={`/post/${p.id}/edit`}>edit</Link>
                )}
              </header>
              {p.imageURL == null || "" ? (
                <img
                  src={
                    "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
                  }
                />
              ) : (
                <img src={p.imageURL} />
              )}
              <div>
                <Link to={`/post/${p.id}`} className="PostList-linkto-post">
                  <div>{p.title}</div>
                </Link>

                <div>{p.author.fullName}</div>
                <div>{p.category.categoryName}</div>
              </div>
            </article>
          ))}
        </section>
      </div>
    </main>
  );
};

export default PostList;

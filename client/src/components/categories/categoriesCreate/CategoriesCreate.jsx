import { useState } from "react";
import { postNewCategory } from "../../../managers/categories";
import { useNavigate } from "react-router-dom";

export const CategoriesCreate = () => {
  const [newCategoryName, setNewCategoryName] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (newCategoryName != "") {
      postNewCategory({ categoryName: newCategoryName }).then(() => {
        navigate("/categories");
      });
    }
  };

  return (
    <main>
      <div className="CategoriesCreate-div-container">
        <form onSubmit={handleSubmit}>
          <article className="CategoriesCreate-article-container">
            <input
              required
              className="CategoriesCreate-input-categoryName"
              value={newCategoryName}
              onChange={(e) => {
                setNewCategoryName(e.target.value);
              }}
            />
            <section>
              <button className="CategoriesCreate-button-submit" type="submit">
                Submit
              </button>
            </section>
          </article>
        </form>
      </div>
    </main>
  );
};

import { useEffect, useState } from "react";
import {
  getCategoryById,
  updateCategoryByCategoryObject,
} from "../../../managers/categories";
import { useNavigate, useParams } from "react-router-dom";

export const CategoriesEdit = () => {
  const [category, setCategory] = useState("");
  const { CategoryId } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getCategoryById(CategoryId).then(setCategory);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (category.categoryName != "") {
      updateCategoryByCategoryObject(category).then(() => {
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
              defaultValue={category.categoryName}
              onChange={(e) => {
                const copy = { ...category };
                copy.categoryName = e.target.value;
                setCategory(copy);
              }}
            />
            <section>
              <button className="CategoriesCreate-button-submit" type="submit">
                Change
              </button>
              <button
                onClick={() => {
                  navigate(`/categories`);
                }}
              >
                Cancel
              </button>
            </section>
          </article>
        </form>
      </div>
    </main>
  );
};
